# Umbraco-Razor-Store-Ucommerce
Custom uCommerce razor store with umbraco

Steps
1) Create a new blank solution project in Visual studio
2) Add a MVC project(Empty)
3) Install latest umbraco using package manager console
4) Run project and complete umbraco installation
5) After installation, goto Developer section and search live packages for ucommerce package or install ucommerce from local zip file
6) Download latest Razor store files from bitbucket https://bitbucket.org/Ucommerce/ucommerce-razor-store/src
7) Take a backup of Controller, Models, Services and Views Folders from the Razor stor files
8) Remove Controller, Models, Services and Views Folders from the Razor stor files
8) Build the project.
7) Goto uCommerce Razor Store\tools\deploy  run the DemoStoreDeploy.cmd. 
8) After the script runs, you will recieve a message saying:

    "Package saved to package\uCommerce_Demo_Store_-_Razor_{version}.zip"

    ..and your package is ready to be installed, through the Developer section of Umbraco's backoffice.

9) Install package\uCommerce_Demo_Store_-_Razor_{version}.zip from developer --> Packages section of our umbraco project

10) It will create a sample store.

11) Copy the Controller, Models, Services and Views Folders from the Razor stor files into our umbraco project root.

12) Run the project.Goto umbraco admin section and publish all nodes

13) Now the frontend is ready to go. Add new category and files.

14) Add new items in the configuration files to allow services Umbraco\ucommerce\Configuration\Custom.config
   <components>
    <component id="DemoStoreWebApi" service="UCommerce.Web.Api.IContainsWebservices, UCommerce.Web.Api" type="UmbUcommerce.AssemblyTag,         UmbUcommerce" />
  </components>
  
  AssemblyTag namespace must be project name. The file is located in Services folder.
  
 15) Update all the files in the Services -> Commands folder
     for example: if the code is like
     ```C#
         public class AddToBasketService : ServiceBase<AddToBasket>
    {
        protected override object Run(AddToBasket request)
        {
            TransactionLibrary.AddToBasket(request.Quantity, request.Sku, request.VariantSku, addToExistingLine: true,    executeBasketPipeline: true);
            return new AddToBasketResponse();
        }
    }
    ```

change it to 
     public class AddToBasketService : Service
    {
        public AddToBasketResponse Post(AddToBasket request)
        {
            TransactionLibrary.AddToBasket(request.Quantity, request.Sku, request.VariantSku, addToExistingLine: true, executeBasketPipeline: true);
            return new AddToBasketResponse();
        }
    }
    
 ServiceBase<AddToBasket> is obselete. https://docs.ucommerce.net/ucommerce/v7.0/extending-ucommerce/add-a-new-web-service/add-a-new-web-service.html
 
 
