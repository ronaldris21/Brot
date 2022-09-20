# API_Rest_CSharp

#		Setup inicial:
		
		On App_Start/WebApiConfig
            //For better looking on Browser! (json idented)
            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
			
		On Global.asax
			//For ignore looping References and Show Post Saqmple in Post Controller for web Deployment
            HttpConfiguration config = GlobalConfiguration.Configuration;
            config.Formatters.JsonFormatter
                        .SerializerSettings
                        .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
#		Other References						
		https://github.com/Zulu55/MyLeasing
		Check this repository for having a better idea of how to create the responser messages

		Ohter basic sample is this one MS Docs about LINQ - WEB API_Rest_CSharp
		<p href="https://github.com/MikeWasson/BookService/blob/master/BookService/Controllers/BooksController.cs">	
			https://github.com/MikeWasson/BookService/blob/master/BookService/Controllers/BooksController.cs
		</p>


#		Defining url paths
		On App_Start/WebApiConfig    **Optional, not need it if HttpVerbs are use o actions names starts with Verb
		config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
			
			
        [Route("api/users/vendors")] **other solution is doing this over every method/action in the controller to define its path
		
          