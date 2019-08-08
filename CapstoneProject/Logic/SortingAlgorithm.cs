using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CapstoneProject.Models;

namespace CapstoneProject.Logic
{
    public class SortingAlgorithm
    {
        private ApplicationDbContext _context;
        public SortingAlgorithm()
        {
            _context = new ApplicationDbContext();
        }
        protected void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public List<Client> GetSpecificDateClients(DateTime oneDay)
        {
            var ClientsPerDay = from c in _context.Clients where c.AvailableTo == oneDay select c;
            return ClientsPerDay.ToList();
        }
        private List<List<Client>> SortSpecificDateClients()
        {
            var dates = GetDatesToLoopThru();

            List<List<Client>> ClientsPerDaySorted = new List<List<Client>> { };

            foreach (DateTime date in dates)
            {

                List<Client> ClientsPerDay = GetSpecificDateClients(date);
                List<Client> ClientsGroup1 = new List<Client> { };
                List<Client> ClientsGroup2 = new List<Client> { };

                foreach (Client client in ClientsPerDay)
                {
                    if (client.GroupNameId == 1)
                    {
                        ClientsGroup1.Add(client);
                    }
                    if (client.GroupNameId == 2)
                    {
                        ClientsGroup2.Add(client);
                    }
                }

                ClientsPerDaySorted.Add(ClientsGroup1);
                ClientsPerDaySorted.Add(ClientsGroup2);
            }

            return ClientsPerDaySorted;

        }

        public List<DateTime> GetDatesToLoopThru()
        {
            List<DateTime> dates = new List<DateTime> { };

            foreach (Client client in _context.Clients)
            {
                if (!dates.Contains(client.AvailableTo))
                {
                    dates.Add(client.AvailableTo);
                }
            }

            return dates;
        }

        private bool IsExactMatch(Client clientOne, Client clientTwo)
        {
            if (clientOne.AvailableTo == clientTwo.AvailableTo &&
                        clientOne.AvailableTo == clientTwo.AvailableTo)
            {
                return true;
            }
            return false;
        }

        //if comparisonclient earlier than client, true. if later, false. if 0, null
        /*public bool IsEarlier(Client clientToSeeIfEarlier, Client client)
        {
            int startTimeComparison = clientToSeeIfEarlier.av
        }*/

        private bool HasNoOverlappingTimeslots(List<Client> clients, Client clientToCompare)
        {
            foreach (Client currentClient in clients)
            {
                if (currentClient != clientToCompare)
                {
                    int startTimeComparison = currentClient.AvailableTo.CompareTo(clientToCompare.AvailableTo);
                    int endTimeComparison = currentClient.AvailableUntil.CompareTo(clientToCompare.AvailableUntil);
                    // x<0 = earlier | x=0 = the same | x>0 = later
                    if (startTimeComparison >= 0 || endTimeComparison <= 0) {}
                    else
                        return false;
                }
            }
            return true;
        }

        private List<List<Client>> GetUnoverlappingTimeslots(List<Client> clients)
        {
            List<Client> unoverlappingSlots = new List<Client>();

            //take out any clients with no overlapping slots
            for (int ixCurrentClient = 0; ixCurrentClient < clients.Count; ixCurrentClient++)
            {
                for (int ixComparing = ixCurrentClient++; ixComparing < clients.Count; ixComparing++)
                {
                    int startTimeComparison = clients[ixCurrentClient].AvailableTo.CompareTo(clients[ixComparing].AvailableTo);
                    int endTimeComparison = clients[ixCurrentClient].AvailableUntil.CompareTo(clients[ixComparing].AvailableUntil);
                    // x<0 = earlier | x=0 = the same | x>0 = later
                    if (startTimeComparison >= 0 || endTimeComparison <= 0)
                    {
                        //not overlapping
                        unoverlappingSlots.Add(clients[ixCurrentClient]);
                    }
                    //else

                }
            }

            List<List<Client>> sortedClients = new List<List<Client>>();
            sortedClients.Add(clients);
            sortedClients.Add(unoverlappingSlots);
            return sortedClients;
        }

        public void MatchClients()
        {
            List<List<Client>> clients = SortSpecificDateClients();
            List<Client> groupOne = clients[0];
            List<Client> groupTwo = clients[1];

            foreach (Client currentClientOne in groupOne)
            {
                foreach (Client currentClientTwo in groupTwo)
                {
                    if (IsExactMatch(currentClientOne, currentClientTwo))
                    {
                        if (HasNoOverlappingTimeslots(groupOne, currentClientOne) &&
                            HasNoOverlappingTimeslots(groupTwo, currentClientTwo))
                        {
                            Match match = new Match();
                            match.Group1_Id = currentClientOne.Id;
                            match.Group2_Id = currentClientTwo.Id;
                            match.Date = currentClientOne.AvailableTo.Date;
                            _context.Matches.Add(match);
                            groupOne.Remove(currentClientOne);
                            groupOne.Remove(currentClientTwo);
                        }
                    }
                }
            }
        }

    //}
}
