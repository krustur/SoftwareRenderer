namespace SoftwareRenderer.Tests
{
    public class ResourceHelper
    {
        public static byte[] ExtractResource(string filename)
        {
            var a = System.Reflection.Assembly.GetExecutingAssembly();
            using (var resFilestream = a.GetManifestResourceStream(filename))
            {
                if (resFilestream == null) return null;
                var ba = new byte[resFilestream.Length];
                resFilestream.Read(ba, 0, ba.Length);
                return ba;
            }
        }
    }
}