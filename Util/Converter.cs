using Microsoft.AspNetCore.Hosting;
using QRCoder;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Renci.SshNet;
namespace ktsstfportal.Util
{
    public class Converter : IConverter
    {
        public async Task<byte[]> ConvertImageToByte(string fileNumber)
        {            
            QRCodeGenerator qr = new();
            QRCodeData codeData = qr.CreateQrCode(fileNumber, QRCodeGenerator.ECCLevel.Q);
            PngByteQRCode qrCode = new(codeData);
            byte[] qrCodeAsBitmapByteArr = qrCode.GetGraphic(20);
            using var ms = new MemoryStream(qrCodeAsBitmapByteArr);
            // var fs = new FileStream("qrcode.png", FileMode.Create, FileAccess.Write);
            // ms.Seek(0, SeekOrigin.Begin);
            // await ms.CopyToAsync(fs);
            return await Task.FromResult(ms.ToArray());            
        }

        public async Task<byte[]> GetImageByte(string value)
        {
            using var stream = new MemoryStream();
            using (SftpClient client = new SftpClient("192.243.108.235","root", "S88D1OLu"))
            {                
                client.KeepAliveInterval = TimeSpan.FromSeconds(60);
                client.ConnectionInfo.Timeout = TimeSpan.FromMinutes(180);
                client.OperationTimeout = TimeSpan.FromMinutes(180);
                client.Connect();
                bool connected = client.IsConnected;
                // RunCommand(host, user, password, "sudo chmod 777 -R " + remotePath);
                client.DownloadFile($"/var/www/ktsstf.org/public_html/CDN/images/{value}", stream);
                stream.Seek(0, SeekOrigin.Begin);                              
                client.Disconnect();
            }            
            return await Task.FromResult(stream.ToArray());
        }
    }
}
