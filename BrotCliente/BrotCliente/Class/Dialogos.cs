using System;
using System.Collections.Generic;
using System.Text;
using Acr.UserDialogs;
using System.Drawing;
namespace BrotCliente.Class
{
    public static class Dialogos
    {
        public static void ToastOk(string mensaje, int miliSegundos)
        {
            ToastConfig toastito = new ToastConfig(mensaje)
                .SetPosition(ToastPosition.Top)
                .SetBackgroundColor(Color.Green)
                .SetMessageTextColor(Color.Black)
                .SetDuration(miliSegundos);

            UserDialogs.Instance.Toast(toastito);
        }

        public static void ToastBAD(string mensaje, int miliSegundos)
        {
            ToastConfig toastito = new ToastConfig(mensaje)
                .SetPosition(ToastPosition.Top)
                .SetBackgroundColor(Color.LightCoral)
                .SetMessageTextColor(Color.Black)
                .SetDuration(miliSegundos);

            UserDialogs.Instance.Toast(toastito);
        }


    }
}
