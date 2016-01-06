using GameStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace GameStore.WebUI.Infrastructure.Binders
{
    class CartModelBinder : System.Web.Mvc.IModelBinder
    {
            private const string sessionKey = "Cart";

        object System.Web.Mvc.IModelBinder.BindModel(ControllerContext controllerContext, System.Web.Mvc.ModelBindingContext bindingContext)
        {
            // Получить объект Cart из сеанса
                Cart cart = null;
                if (controllerContext.HttpContext.Session != null)
                {
                    cart = (Cart)controllerContext.HttpContext.Session[sessionKey];
                }

                // Создать объект Cart если он не обнаружен в сеансе
                if (cart == null)
                {
                    cart = new Cart();
                    if (controllerContext.HttpContext.Session != null)
                    {
                        controllerContext.HttpContext.Session[sessionKey] = cart;
                    }
                }

                // Возвратить объект Cart
                return cart;
        }
    }
    }

