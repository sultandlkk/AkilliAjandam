using System;

namespace AkilliAjandam1
{
    internal class TesseractEngine : IDisposable
    {
        private string v1;
        private string v2;
        private object @default;

        public TesseractEngine(string v1, string v2, object @default)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.@default = @default;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}