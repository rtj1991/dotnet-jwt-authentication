using ProductAPI.Models;
using ProductAPI.Container.Entity;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

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

    public Task<List<Places>> GetAll()
    {
        List<Places> resp = new List<Places>();

        var _place = _DBContext.Places.Include(b => b.MyTrips).ToList();
        if (_place != null)
        {
            resp = _mapper.Map<List<Places>, List<Places>>(_place);
        }
        else
        {
            throw new NullReferenceException("Getting Null while fetching Places details");
        }
        return Task.FromResult(resp);
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
                throw new NullReferenceException("Getting Null while fetching Places details");
            }
        }
        catch (ArgumentNullException e)
        {
            throw new ArgumentNullException("Getting Error while Argument Pass " + e.Message);
        }
    }

    public async Task<bool> Remove(int id)
    {

        try
        {
            var place = await _DBContext.Places.FindAsync(id);
            if (place == null)
            {
                throw new NullReferenceException("Getting Null while fetching Places details");
            }
            else
            {
                this._DBContext.Remove(place);
                await this._DBContext.SaveChangesAsync();
                return true;
            }
        }
        catch (ArgumentNullException e)
        {
            throw new ArgumentNullException("Getting Error while Argument Pass " + e.Message);
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
                if (places.Description != null)
                {
                    _places.Description = places.Description;
                }
                else
                {
                    _places.Description = _places.Description;
                }

                if (places.Coordinates != null)
                {
                    _places.Coordinates = places.Coordinates;
                }
                else
                {
                    _places.Coordinates = _places.Coordinates;
                }

                if (places.Name != null)
                {
                    _places.Name = places.Name;
                }
                else
                {
                    _places.Name = _places.Name;
                }

                if (!places.TripId.Equals(null))
                {
                    _places.TripId = places.TripId;
                }
                else
                {
                    _places.TripId = _places.TripId;
                }


                this._DBContext.Update(_places);
                await this._DBContext.SaveChangesAsync();

                return true;
            }
            else
            {
                throw new NullReferenceException("Getting Null while fetching Places details");
            }
        }
        catch (ArgumentNullException e)
        {
            throw new ArgumentNullException("Getting Error while Argument Pass " + e.Message);
        }
    }
}
