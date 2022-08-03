using ProductAPI.Models;
using ProductAPI.Container.Entity;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ProductAPI.Container;

public class TripContainer : ITripContainer
{

    private readonly travellerContext _DBContext;
    private readonly IMapper _mapper;

    public TripContainer(travellerContext _DBContext, IMapper _mapper)
    {
        this._DBContext = _DBContext;
        this._mapper = _mapper;
    }

    public async Task<List<MyTrip>> GetAll()
    {
        List<MyTrip> resp = new List<MyTrip>();

        var _trip = _DBContext.MyTrips.Include(b => b.Place).ToList();
        if (_trip != null)
        {
            resp = _mapper.Map<List<MyTrip>, List<MyTrip>>(_trip);
        }
        return resp;
    }

    public async Task<MyTrip> GetById(int id)
    {

        try
        {
            var my_trips = await _DBContext.MyTrips.Include(m => m.Place).Where(m => m.Id == id).SingleOrDefaultAsync();

            if (my_trips != null)
            {
                MyTrip resp = _mapper.Map<MyTrip, MyTrip>(my_trips);
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
            var my_trips = await _DBContext.MyTrips.FindAsync(id);
            if (my_trips == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                this._DBContext.Remove(my_trips);
                await this._DBContext.SaveChangesAsync();
                return true;
            }
        }
        catch (System.Exception)
        {

            throw new ApplicationException("Getting Errors while fetching my trip details");
        }

    }

    public async Task<bool> Save(MyTrip myTrip)
    {
        this._DBContext.Add(myTrip);
        await this._DBContext.SaveChangesAsync();

        return true;
    }

    public async Task<bool> Edit(int id, MyTrip trip)
    {

        try
        {
            var my_trips = await _DBContext.MyTrips.FindAsync(id);
            if (my_trips != null)
            {
                my_trips.Description = trip.Description;
                my_trips.EndDate = trip.EndDate;
                my_trips.Location = trip.Location;
                my_trips.StartDate = trip.StartDate;
                my_trips.Status = trip.Status;
                my_trips.Place = trip.Place;
                my_trips.TimestampModified = DateTime.UtcNow;
                this._DBContext.Update(my_trips);
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