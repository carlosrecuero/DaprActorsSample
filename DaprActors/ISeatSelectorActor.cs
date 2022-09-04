using Dapr.Actors;

namespace DaprActors
{

    public interface ISeatSelectorActor : IActor
    {
        Task<Seat> GetSeat(string seatName);
        Task AssignSeat(Seat seat);
        Task UnassignSeat(Seat seat);
    }
}
