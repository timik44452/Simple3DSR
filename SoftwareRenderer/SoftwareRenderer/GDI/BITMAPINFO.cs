using System.Runtime.InteropServices;

namespace SoftwareRenderer.GDI
{
    [StructLayout(LayoutKind.Sequential)]
    public struct BITMAPINFO
    {
        public BITMAPINFOHEADER biHeader;
        public int biColors;
    }
}
