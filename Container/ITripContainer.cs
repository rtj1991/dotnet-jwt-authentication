using Microsoft.AspNetCore.Mvc;
using ProductAPI.Models;
namespace ProductAPI.Container.Entity;

public interface ITripContainer
{

     Task<List<MyTrip>> GetAll();

     Task<TripEntity> GetById(int id);

     Task<bool>Remove(int id);

     Task<bool>Save(MyTrip trip);

     Task<bool>Edit(int id,MyTrip trip);

}