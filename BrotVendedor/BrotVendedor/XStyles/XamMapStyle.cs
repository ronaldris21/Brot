using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace BrotVendedor.XStyles
{
    public class XamMapStyle
    {
        public String text;
        public XamMapStyle()
        {
            AssignText();
        }
        public void AssignText()
        {
            try
            {
                var assembly = IntrospectionExtensions.GetTypeInfo(typeof(XamMapStyle)).Assembly;
                Stream stream = assembly.GetManifestResourceStream("BrotVendedor.XStyles.XMapStyle.json");

                using (var reader = new System.IO.StreamReader(stream))
                {
                    var json = reader.ReadToEnd();

                    this.text = json;
                }

            }
            catch (Exception ex)
            {
            }
        }
    }
}
