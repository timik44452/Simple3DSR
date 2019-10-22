using System.IO;
using System.Collections.Generic;

namespace SoftwareRenderer
{
    public class Primitives
    {
        private const string PRIMITIVES_FOLDER = @"Primitives";


        public static Mesh GetPrimitive(string name)
        {
            if (!Directory.Exists(PRIMITIVES_FOLDER))
            {
                Directory.CreateDirectory(PRIMITIVES_FOLDER);
            }

            var primitiveUnwrap = Sevice.Serializator.Deserialization<MeshSerializationContainer>(Path.Combine(PRIMITIVES_FOLDER, $@"{name}.xml"));

            if (primitiveUnwrap != null)
            {
                return primitiveUnwrap.ToMesh();
            }

            throw new System.Exception($"Primitive {name} hasn't find");
        }
    }
}
