using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CapstoneProject.Models;

namespace CapstoneProject.Logic
{
    //public class SortingAlgorithm
    //{
    //    private ApplicationDbContext _context;
    //    public SortingAlgorithm()
    //    {
    //        _context = new ApplicationDbContext();
    //    }
    //    protected void Dispose(bool disposing)
    //    {
    //        _context.Dispose();
    //    }

    //    public List<Client> GetSpecificDateClients(DateTime oneDay)
    //    {
    //        var ClientsPerDay = from c in _context.Clients where c.AvailableTo == oneDay select c;
    //        return ClientsPerDay.ToList();
    //    }
    //    private List<List<Client>> SortSpecificDateClients()
    //    {
    //        var dates = GetDatesToLoopThru();

    //        List<List<Client>> ClientsPerDaySorted = new List<List<Client>> { };

    //        foreach (DateTime date in dates)
    //        {

    //            List<Client> ClientsPerDay = GetSpecificDateClients(date);
    //            List<Client> ClientsGroup1 = new List<Client> { };
    //            List<Client> ClientsGroup2 = new List<Client> { };

    //            foreach (Client client in ClientsPerDay)
    //            {
    //                if (client.GroupNameId == 1)
    //                {
    //                    ClientsGroup1.Add(client);
    //                }
    //                if (client.GroupNameId == 2)
    //                {
    //                    ClientsGroup2.Add(client);
    //                }
    //            }

    //            ClientsPerDaySorted.Add(ClientsGroup1);
    //            ClientsPerDaySorted.Add(ClientsGroup2);
    //        }

    //        return ClientsPerDaySorted;

    //    }

    //    public List<DateTime> GetDatesToLoopThru()
    //    {
    //        List<DateTime> dates = new List<DateTime> { };

    //        foreach (Client client in _context.Clients)
    //        {
    //            if (!dates.Contains(client.AvailableTo))
    //            {
    //                dates.Add(client.AvailableTo);
    //            }
    //        }

    //        return dates;
    //    }

    //    private bool IsExactMatch(Client clientOne, Client clientTwo)
    //    {
    //        if (clientOne.AvailableTo == clientTwo.AvailableTo &&
    //                    clientOne.AvailableTo == clientTwo.AvailableTo)
    //        {
    //            return true;
    //        }
    //        return false;
    //    }

    //    private bool HasNoOverlappingTimeslots(List<Client> clients, Client clientToCompare)
    //    {
    //        foreach (Client currentClient in clients)
    //        {
    //            if (currentClient != clientToCompare)
    //            {
    //                int startTimeComparison = currentClient.AvailableTo.CompareTo(clientToCompare.AvailableTo);
    //                int endTimeComparison = currentClient.AvailableTo.CompareTo(clientToCompare.AvailableTo);
    //                // x<0 = earlier | x=0 = the same | x>0 = later
    //                if (startTimeComparison >= 0 || endTimeComparison <= 0) {}
    //                else
    //                    return false;
    //            }
    //        }
    //        return true;
    //    }

    //    public void MatchClients()
    //    {
    //        List<List<Client>> clients = SortSpecificDateClients();
    //        List<Client> groupOne = clients[0];
    //        List<Client> groupTwo = clients[1];

    //        foreach (Client currentClientOne in groupOne)
    //        {
    //            foreach (Client currentClientTwo in groupTwo)
    //            {
    //                if (IsExactMatch(currentClientOne, currentClientTwo))
    //                {
    //                    if (HasNoOverlappingTimeslots(groupOne, currentClientOne) &&
    //                        HasNoOverlappingTimeslots(groupTwo, currentClientTwo))
    //                    {
    //                        Match match = new Match();
    //                        match.Group1_Id = currentClientOne.Id;
    //                        match.Group2_Id = currentClientTwo.Id;
    //                        match.Date = currentClientOne.AvailableTo.Date;
    //                        _context.Matches.Add(match);
    //                    }
    //                }
    //            }
    //        }
    //    }
        
    //}
}