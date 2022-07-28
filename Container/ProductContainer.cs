using ProductAPI.Models;
using ProductAPI.Container.Entity;
using Microsoft.EntityFrameworkCore;
using AutoMapper;


namespace ProductAPI.Container;

public class ProductContainer : IProductContainer
{

    private readonly travellerContext _DBContext;
    private readonly IMapper _mapper;

    public ProductContainer(travellerContext _DBContext,IMapper _mapper)
    {
        this._DBContext = _DBContext;
        this._mapper=_mapper;
    }

    public async Task<List<MyTrip>> GetAll()
    {
        List<MyTrip> resp = new List<MyTrip>();
        var _trip = await _DBContext.MyTrips.ToListAsync();
        if (_trip != null)
        {
            resp=_mapper.Map<List<MyTrip>,List<MyTrip>>(_trip);
        }
        return resp;
    }


}