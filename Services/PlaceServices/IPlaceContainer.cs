using Microsoft.AspNetCore.Mvc;
using ProductAPI.Models;
namespace ProductAPI.Container.Entity;

public interface IPlaceContainer
{

     Task<List<Places>> GetAll();

     Task<Places> GetById(int id);

     Task<bool>Remove(int id);

     Task<bool>Save(Places places);

     Task<bool>Edit(int id,Places places);

}