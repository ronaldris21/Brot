﻿namespace BrotCliente.Patterns
{
    using BrotCliente.Services;
    using DLL.Models;
    using System;
    using Xamarin.Forms;
    public class btnLikePostTrigger : TriggerAction<ImageButton>
    {
        protected async override void Invoke(ImageButton sender)
        {
            bool isliked;
            isliked = (bool)((ImageButton)sender).CommandParameter;
            //Saber si ya era like o no? Retorna FALSE para el pin negro y retorna True para el pin Naranja
            var like = new like_postModel()
            {
                id_post = Convert.ToInt32(((ImageButton)sender).ClassId),
                id_user = Singleton.Instance.User.id_user
            };
            if (isliked)
            {
                //Se quita el like
                ((ImageButton)sender).Source = "PinBlack250.png";
                await RestClient.Post<like_postModel>("like_post/borrar", like);
            }
            else
            {
                //se crea el like!
                ((ImageButton)sender).Source = "Pin250.png";
                await RestClient.Post<like_postModel>("like_post", like);
            }
            ((ImageButton)sender).CommandParameter = !isliked;

        }
    }
}
