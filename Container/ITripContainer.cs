using Microsoft.AspNetCore.Mvc;
using ProductAPI.Models;
namespace ProductAPI.Container.Entity;

public interface ITripContainer
{

     Task<List<TripEntity>> GetAll();

     Task<TripEntity> GetById(int id);

     Task<bool>Remove(int id);

     Task<bool>Save(TripEntity tripEntity);

}