using System;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace DeveTetris99Bot.Capture
{
    public class MyStreamWriter : IStream
    {
        public BinaryWriter bWriter;

        public MyStreamWriter()
        {
            bWriter = new BinaryWriter(
                File.OpenWrite("graph.grf"),
                Encoding.UTF8);
        }

        public void Clone(out IStream ppstm)
        {
            throw new NotImplementedException();
        }

        public void Commit(int grfCommitFlags)
        {
            bWriter.Flush();
            throw new NotImplementedException();
        }

        public void CopyTo(IStream pstm, long cb, IntPtr pcbRead, IntPtr pcbWritten)
        {
            throw new NotImplementedException();
        }

        public void LockRegion(long libOffset, long cb, int dwLockType)
        {
            throw new NotImplementedException();
        }

        public void Read(byte[] pv, int cb, IntPtr pcbRead)
        {
            throw new NotImplementedException();
        }

        public void Revert()
        {
            throw new NotImplementedException();
        }

        public void Seek(long dlibMove, int dwOrigin, IntPtr plibNewPosition)
        {
            bWriter.Seek((int)dlibMove, (SeekOrigin)dwOrigin);
        }

        public void SetSize(long libNewSize)
        {
            throw new NotImplementedException();
        }

        public void Stat(out STATSTG pstatstg, int grfStatFlag)
        {
            throw new NotImplementedException();
        }

        public void UnlockRegion(long libOffset, long cb, int dwLockType)
        {
            throw new NotImplementedException();
        }

        public void Write(byte[] pv, int cb, IntPtr pcbWritten)
        {
            bWriter.Write(pv);
        }
    }
}
