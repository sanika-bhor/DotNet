using System.Text.Json.Serialization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Net.Http.Headers;

namespace Model.Cart;

[Serializable]
public class Cart
{

  public List<Item> Items = new List<Item>();
  public Cart()
  {
  }

}