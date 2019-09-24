using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;
using System.Diagnostics;

namespace BrotCliente.XamarinStyles
{
    public class XamarinMapStyle
    {
        public string Text;

        public XamarinMapStyle()
        {
            Read();
        }

        private void Read()
        {
            try
            {
                var assembly = IntrospectionExtensions.GetTypeInfo(typeof(XamarinMapStyle)).Assembly;
                Stream stream = assembly.GetManifestResourceStream("BrotCliente.XamarinStyles.MapStyleBrot.json");

                using (var reader = new System.IO.StreamReader(stream))
                {
                    var json = reader.ReadToEnd();

                    this.Text = json;
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
