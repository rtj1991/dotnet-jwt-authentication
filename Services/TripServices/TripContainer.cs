using ProductAPI.Models;
using ProductAPI.Container.Entity;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

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

    public Task<List<MyTrip>> GetAll()
    {
        List<MyTrip> resp = new List<MyTrip>();

        var _trip = _DBContext.MyTrips.Include(b => b.Place).ToList();
        if (_trip != null)
        {
            resp = _mapper.Map<List<MyTrip>, List<MyTrip>>(_trip);
        }
        else
        {
            throw new NullReferenceException("Getting Null while fetching My Trip details");
        }
        return Task.FromResult(resp);
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
            var my_trips = await _DBContext.MyTrips.FindAsync(id);
            if (my_trips == null)
            {
                throw new NullReferenceException("Getting Null while fetching My Trip details");
            }
            else
            {
                this._DBContext.Remove(my_trips);
                await this._DBContext.SaveChangesAsync();
                return true;
            }
        }
        catch (ArgumentNullException e)
        {
            throw new ArgumentNullException("Getting Error while Argument Pass " + e.Message);
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
                if (trip.Description != null)
                {
                    my_trips.Description = trip.Description;
                }
                else
                {
                    my_trips.Description = my_trips.Description;
                }

                if (trip.EndDate != null)
                {
                    my_trips.EndDate = trip.EndDate;
                }
                else
                {
                    my_trips.EndDate = my_trips.EndDate;
                }

                if (trip.Location != null)
                {
                    my_trips.Location = trip.Location;
                }
                else
                {
                    my_trips.Location = my_trips.Location;
                }
                if (trip.StartDate != null)
                {
                    my_trips.StartDate = trip.StartDate;
                }
                else
                {
                    my_trips.StartDate = my_trips.StartDate;
                }

                if (trip.Status != null)
                {
                    my_trips.Status = trip.Status;
                }
                else
                {
                    my_trips.Status = my_trips.Status;
                }

                if (trip.Place != null)
                {
                    my_trips.Place = trip.Place;
                }
                else
                {
                    my_trips.Place = my_trips.Place;
                }


                my_trips.TimestampModified = DateTime.UtcNow;
                this._DBContext.Update(my_trips);
                await this._DBContext.SaveChangesAsync();

                return true;
            }
            else
            {
                throw new NullReferenceException("Getting Null while fetching My Trip details");
            }
        }
        catch (ArgumentNullException e)
        {
            throw new ArgumentNullException("Getting Error while Argument Pass " + e.Message);
        }

    }


}