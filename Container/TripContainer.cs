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

    public async Task<List<TripEntity>> GetAll()
    {
        List<TripEntity> resp = new List<TripEntity>();
        var _trip = await _DBContext.MyTrips.ToListAsync();
        if (_trip != null)
        {
            resp = _mapper.Map<List<MyTrip>, List<TripEntity>>(_trip);
        }
        return resp;
    }

    public async Task<TripEntity> GetById(int id)
    {

        var my_trips = await _DBContext.MyTrips.FindAsync(id);

        if (my_trips != null)
        {
            TripEntity resp = _mapper.Map<MyTrip, TripEntity>(my_trips);
            return resp;
        }
        else
        {
            return new TripEntity();
        }

    }

    public async Task<bool> Remove(int id)
    {
        var my_trips = await _DBContext.MyTrips.FindAsync(id);
        if (my_trips == null)
        {
            return false;
        }
        else
        {
            this._DBContext.Remove(my_trips);
            await this._DBContext.SaveChangesAsync();
            return true;
        }
    }

    public async Task<bool> Save(TripEntity tripEntity)
    {

        Console.WriteLine("tripEntity===> " + tripEntity.Description);
        MyTrip _mytrip = new MyTrip();
        _mytrip.Location = tripEntity.Location;
        _mytrip.Description = tripEntity.Description;
        this._DBContext.Add(_mytrip);
        await this._DBContext.SaveChangesAsync();

        return true;
    }


}