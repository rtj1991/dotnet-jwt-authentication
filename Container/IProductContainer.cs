using Microsoft.AspNetCore.Mvc;
using ProductAPI.Models;
namespace ProductAPI.Container.Entity;

public interface IProductContainer
{

     Task<List<MyTrip>> GetAll();

    //  Task<TripEntity> GetById(int id);

    //  Task<TripEntity>Remove(int id);

    //  Task<bool>Save(TripEntity tripEntity);

}