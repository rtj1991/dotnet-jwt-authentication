using AutoMapper;
using ProductAPI.Container.Entity;
using ProductAPI.Models;

public class AutoMapperHandler:Profile
{
   public AutoMapperHandler(){
    CreateMap<MyTrip,TripEntity>().ForMember(trip=>trip.Location,opt=>opt.MapFrom(item=>item.Description));

   }
}