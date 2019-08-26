using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VISCALib
{
    public class VISCACommands
    {
        byte[] setAddress = { 0x88, 0x30, 0x01, 0xff };
        byte[] ifClear = { 0x88, 0x01, 0x00, 0x01, 0xff };

        private static byte[] setCamId(byte[] buf, int camId)
        {
            buf[0] = (byte) (0x80 + camId);
            return buf;
        }

        public static byte[] cmdCancel(int camId, int socketId)
        {
            byte[] buf = { 0x80, 0x20, 0xff };
            buf = setCamId(buf, camId);
            buf[1] = (byte) (socketId + 0x20);
            buf[2] = 0xff;
            return buf;
        }
        public static byte[] swOn(int camId)
        {
            byte[] buf = { 0x80, 0x01, 0x04, 0x00, 0x02, 0xff };
            buf = setCamId(buf, camId);
            return buf;
        }
        public static byte[] swOff(int camId)
        {
            byte[] buf = { 0x80, 0x01, 0x04, 0x00, 0x03, 0xff };
            buf = setCamId(buf, camId);
            return buf;
        }
        public static byte[] zoomStop(int camId)
        {
            byte[] buf = { 0x80, 0x01, 0x04, 0x07, 0x00, 0xff };
            buf = setCamId(buf, camId);
            return buf;
        }
        public static byte[] zoomTele(int camId, int speed)
        {
            byte[] buf = { 0x80, 0x01, 0x04, 0x07, 0x20, 0xff };
            buf = setCamId(buf, camId);
            buf[4] += (byte)speed;
            return buf;
        }
        public static byte[] zoomWide(int camId, int speed)
        {
            byte[] buf = { 0x80, 0x01, 0x04, 0x07, 0x30, 0xff };
            buf = setCamId(buf, camId);
            buf[4] += (byte)speed;
            return buf;
        }
        public static byte[] zoomPos(int camId, int pos)
        {
            byte[] buf = { 0x80, 0x01, 0x04, 0x47, 0x00, 0x00, 0x00, 0x00, 0xff };
            buf = setCamId(buf, camId);
            if(pos >> 0x0c > 0x0)
            {
                buf[4] = (byte)(pos >> 0x0c);
                pos -= pos >> 0x0c;
            }
            if (pos >> 0x08 > 0x0)
            {
                buf[5] = (byte)(pos >> 0x08);
                pos -= pos >> 0x08;
            }
            if (pos >> 0x04 > 0x0)
            {
                buf[6] = (byte)(pos >> 0x04);
                pos -= pos >> 0x04;
            }
            buf[7] = (byte)pos;
            return buf;
        }
        public static byte[] focusStop(int camId)
        {
            byte[] buf = { 0x80, 0x01, 0x04, 0x08, 0x00, 0xff };
            buf = setCamId(buf, camId);
            return buf;
        }
        public static byte[] focusFar(int camId, int speed)
        {
            byte[] buf = { 0x80, 0x01, 0x04, 0x08, 0x20, 0xff };
            buf = setCamId(buf, camId);
            buf[4] += (byte)speed;
            return buf;
        }
        public static byte[] focusNear(int camId, int speed)
        {
            byte[] buf = { 0x80, 0x01, 0x04, 0x08, 0x30, 0xff };
            buf = setCamId(buf, camId);
            buf[4] += (byte)speed;
            return buf;
        }
        public static byte[] focusPos(int camId, int pos)
        {
            byte[] buf = { 0x80, 0x01, 0x04, 0x47, 0x00, 0x00, 0x00, 0x00, 0xff };
            buf = setCamId(buf, camId);
            if (pos >> 0x0c > 0x0)
            {
                buf[4] = (byte)(pos >> 0x0c);
                pos -= pos >> 0x0c;
            }
            if (pos >> 0x08 > 0x0)
            {
                buf[5] = (byte)(pos >> 0x08);
                pos -= pos >> 0x08;
            }
            if (pos >> 0x04 > 0x0)
            {
                buf[6] = (byte)(pos >> 0x04);
                pos -= pos >> 0x04;
            }
            buf[7] = (byte)pos;
            return buf;
        }
        public static byte[] focusInf(int camId)
        {
            byte[] buf = { 0x80, 0x01, 0x04, 0x18, 0x02, 0xff };
            buf = setCamId(buf, camId);
            return buf;
        }
        public static byte[] focusAF(int camId)
        {
            byte[] buf = { 0x80, 0x01, 0x04, 0x38, 0x02, 0xff };
            buf = setCamId(buf, camId);
            return buf;
        }
        public static byte[] focusMF(int camId)
        {
            byte[] buf = { 0x80, 0x01, 0x04, 0x38, 0x03, 0xff };
            buf = setCamId(buf, camId);
            return buf;
        }
        public static byte[] focusToggle(int camId)
        {
            byte[] buf = { 0x80, 0x01, 0x04, 0x38, 0x10, 0xff };
            buf = setCamId(buf, camId);
            return buf;
        }
        public static byte[] focusOnePush(int camId)
        {
            byte[] buf = { 0x80, 0x01, 0x04, 0x18, 0x01, 0xff };
            buf = setCamId(buf, camId);
            return buf;
        }
        public static byte[] whiteAuto(int camId)
        {
            byte[] buf = { 0x80, 0x01, 0x04, 0x35, 0x00, 0xff };
            buf = setCamId(buf, camId);
            return buf;
        }

        public static byte[] whiteIndoor(int camId)
        {
            byte[] buf = { 0x80, 0x01, 0x04, 0x35, 0x01, 0xff };
            buf = setCamId(buf, camId);
            return buf;
        }

        public static byte[] whiteOutdoor(int camId)
        {
            byte[] buf = { 0x80, 0x01, 0x04, 0x35, 0x02, 0xff };
            buf = setCamId(buf, camId);
            return buf;
        }

        public static byte[] whiteOnePush(int camId)
        {
            byte[] buf = { 0x80, 0x01, 0x04, 0x35, 0x03, 0xff };
            buf = setCamId(buf, camId);
            return buf;
        }

        public static byte[] whiteManual(int camId)
        {
            byte[] buf = { 0x80, 0x01, 0x04, 0x35, 0x05, 0xff };
            buf = setCamId(buf, camId);
            return buf;
        }

        public static byte[] whiteTrigOnePush(int camId)
        {
            byte[] buf = { 0x80, 0x01, 0x04, 0x10, 0x05, 0xff };
            buf = setCamId(buf, camId);
            return buf;
        }
    }
}
