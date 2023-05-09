using System;
using System.Linq;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace UltiLaunch2
{
    internal class Ultimate
    {
        public string hostName = null;
        public int port = 64;

        static public readonly string[] extensions = new[] { ".prg", ".d64", ".crt" };

        enum Command : ushort
        {
            DMA         = 0xFF01,
            DMARUN      = 0xFF02,
            KEYB        = 0xFF03,
            RESET       = 0xFF04,
            WAIT	    = 0xFF05,
            DMAWRITE    = 0xFF06,
            REUWRITE    = 0xFF07,
            KERNALWRITE = 0xFF08,
            DMAJUMP     = 0xFF09,
            MOUNT_IMG   = 0xFF0A,
            RUN_IMG     = 0xFF0B,
            POWEROFF    = 0xFF0C,
            RUN_CRT     = 0xFF0D,
        }
     
        public void Mount(string path, bool run)
        {
            var data = File.ReadAllBytes(path);
            switch (Path.GetExtension(path).ToLowerInvariant())
            {
                case ".d64":
                    Send(run ? Command.RUN_IMG : Command.MOUNT_IMG, data);
                    break;
                case ".prg":
                    Send(run ? Command.DMARUN : Command.DMAWRITE, data);
                    break;
                case ".crt":
                    Send(Command.RUN_CRT, data);
                    break;
            }
        }

        void Send(Command cmd, byte[] payload = null)        
        { 
            payload = payload ?? Array.Empty<byte>();

            if (String.IsNullOrEmpty(hostName))
                throw new Exception("Please set the cartridge host name or address");

            var address = Dns.GetHostAddresses(hostName).FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork) 
                          ?? throw new Exception($"Can't resolve host name '{hostName}");

            using (var client = new TcpClient())
            {
                client.Connect(address, port);

                using (var bw = new BinaryWriter(client.GetStream()))
                {

                    bw.Write((ushort)cmd);
                    if ((cmd == Command.MOUNT_IMG) || (cmd == Command.RUN_IMG) || (cmd == Command.RUN_CRT))
                    {
                        bw.Write((byte)(payload.Length & 0xff));
                        bw.Write((byte)((payload.Length >> 8) & 0xff));
                        bw.Write((byte)((payload.Length >> 16) & 0xff));
                    }
                    else
                        bw.Write((ushort)payload.Length);

                    bw.Write(payload);
                }
            }
        }


    }
}
