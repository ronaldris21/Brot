using BrotApi0.Models;
using DLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.RepositoryController
{
    public class RUsers
    {

        #region Gets

        //Obtener todas los usuarios
        public ResponseModel getUsersAll()
        {
            return new ResponseModel();
        }



        //Obtener un usuario
        public ResponseModel getUser(int idUser)
        {
            return new ResponseModel();
        }



        //Vendors obtener vendedores
        public ResponseModel vendors()
        {
            return new ResponseModel();
        }



        //Brot Ten
        public ResponseModel brotten()
        {
            return new ResponseModel();
        }



        //MostLiked
        public ResponseModel mostliked()
        {
            return new ResponseModel();
        }



        //Vendores mas vistos MostViewed
        public ResponseModel mostviewed()
        {
            return new ResponseModel();
        }

        //Perfil del usuario con publicaciones y cantidad de seguidores
        public ResponseModel userprofile(int idUser)
        {
            //
            return new ResponseModel();
        }



        //Perfil del usuario con publicaciones y cantidad de seguidores
        public ResponseModel Clientprofile(int idUser)
        {
            return new ResponseModel();
        }


        //Seguidores por usuario
        public ResponseModel getSeguidores(int idUser)
        {
            return new ResponseModel();
        }


        //Seguidos por usuario
        public ResponseModel getSeguidos(int idUser)
        {
            return new ResponseModel();
        }

        #endregion

        #region Post Methods
        //Obtener el usuario completo, con contraseña password y dui
        public ResponseModel getUserComplete(int idUser)
        {
            return new ResponseModel();
        }

        //Signup
        public ResponseModel signup(userModel item)
        {
            return new ResponseModel();
        }

        //Login
        public ResponseModel login(userModel item)
        {
            //Retorno objeto con id
            return new ResponseModel();
        }

        #endregion

        #region Update

        // PUT: api/users/5
        public ResponseModel Putusers(int id, userModel users)
        {
            return new ResponseModel();
        }

        #endregion

        #region Delete

        // DELETE: api/users/5
        public ResponseModel Deleteusers(int id)
        {

            return new ResponseModel();
        }

        #endregion


    }
}
