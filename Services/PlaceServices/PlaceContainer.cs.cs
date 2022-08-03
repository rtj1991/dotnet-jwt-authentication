using ProductAPI.Models;
using ProductAPI.Container.Entity;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ProductAPI.Container;

public class PlaceContainer : IPlaceContainer
{

    private readonly travellerContext _DBContext;
    private readonly IMapper _mapper;

    public PlaceContainer(travellerContext _DBContext, IMapper _mapper)
    {
        this._DBContext = _DBContext;
        this._mapper = _mapper;
    }

    public async Task<List<Places>> GetAll()
    {
        List<Places> resp = new List<Places>();

        var _place = _DBContext.Places.Include(b => b.MyTrips).ToList();
        if (_place != null)
        {
            resp = _mapper.Map<List<Places>, List<Places>>(_place);
        }
        return resp;
    }

    public async Task<Places> GetById(int id)
    {

        try
        {

            var place = await _DBContext.Places.Include(m => m.MyTrips).Where(m => m.Id == id).SingleOrDefaultAsync();

            if (place != null)
            {
                Places resp = _mapper.Map<Places, Places>(place);
                return resp;
            }
            else
            {
                throw new ApplicationException("Getting Null while fetching my trip details");
            }
        }
        catch (System.Exception)
        {
            throw new ApplicationException("Getting Errors while fetching my trip details");
        }


    }

    public async Task<bool> Remove(int id)
    {

        try
        {
            var place = await _DBContext.Places.FindAsync(id);
            if (place == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                this._DBContext.Remove(place);
                await this._DBContext.SaveChangesAsync();
                return true;
            }
        }
        catch (System.Exception)
        {

            throw new ApplicationException("Getting Errors while fetching my trip details");
        }

    }

    public async Task<bool> Save(Places places)
    {
        this._DBContext.Add(places);
        await this._DBContext.SaveChangesAsync();

        return true;
    }

    public async Task<bool> Edit(int id, Places places)
    {

        try
        {
            var _places = await _DBContext.Places.FindAsync(id);
            if (_places != null)
            {
                _places.Description = places.Description;
                _places.Coordinates = places.Coordinates;
                _places.Name = places.Name;
                _places.TripId = places.TripId;

                this._DBContext.Update(_places);
                await this._DBContext.SaveChangesAsync();

                return true;
            }
            else
            {
                throw new ArgumentNullException();
            }

        }
        catch (System.Exception)
        {

            throw new ArgumentNullException();
        }

    }

}