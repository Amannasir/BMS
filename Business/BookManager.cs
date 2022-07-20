
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.PowerPlatform.Dataverse.Client;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using BMS.Providers;

namespace BMS.Data.Business
{
    public class BookManager : IBookManager
    {
        readonly ServiceClient client;
        readonly IDataverseProvider dataverseProvider;
        public BookManager(IDataverseProvider dataverseProvider)
        {
            this.dataverseProvider = dataverseProvider;
            this.client = this.dataverseProvider.GetServiceClient();
        }


        private static MBook MapToLead(Entity entity)
        {
            var result = new MBook();

            result.Id = entity.GetAttributeValue<Guid>("mgt_bookid");
            result.Title = entity.GetAttributeValue<string>("mgt_name");
            result.Author = entity.GetAttributeValue<string>("mgt_author");
            result.Description = entity.GetAttributeValue<string>("mgt_description");
            result.Rate = entity.GetAttributeValue<Int32>("mgt_rate");
            result.DateStart = entity.GetAttributeValue<DateTime>("mgt_datestarted");
            result.DateRead = entity.GetAttributeValue<DateTime>("mgt_dateread");
           

            return result;
        }

       
        public async Task<MBook> GetByIdAsync(Guid id)
        {
            var entity = await client.RetrieveAsync("mgt_book", id, new ColumnSet("mgt_bookid", "mgt_name", "mgt_author", "mgt_description", "mgt_rate", "mgt_datestarted", "mgt_dateread"));
            var record = MapToLead(entity);
            return record;
        }

        public async Task<List<MBook>> GetListAsync()
        {
            var query = new QueryExpression
            {
                EntityName = "mgt_book",
                ColumnSet = new ColumnSet("mgt_bookid", "mgt_name", "mgt_author", "mgt_description", "mgt_rate", "mgt_datestarted", "mgt_dateread"),
               // Criteria = new FilterExpression()
            };

           // query.Criteria.AddCondition("parentcontactid", ConditionOperator.Equal, contactId);
            var entityCollection = await client.RetrieveMultipleAsync(query);
            var list = entityCollection.Entities.Select(entity => MapToLead(entity)).ToList();
            return list;
        }

        public async Task UpdateAsync(MBook book)
        {
            var entity = await client.RetrieveAsync("mgt_book", book.Id.Value, new ColumnSet(true));
            entity["mgt_bookid"] = book.Id;
            entity["mgt_name"] = book.Title;
            entity["mgt_author"] = book.Author;
            entity["mgt_description"] = book.Description;
            entity["mgt_rate"] = book.Rate;
            entity["mgt_datestarted"] = book.DateStart;
            entity["mgt_dateread"] = book.DateRead;

            await client.UpdateAsync(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            await client.DeleteAsync("mgt_book", id);
        }

        public async Task<MBook> CreateAsync(MBook book)
        {
            var entity = new Entity("mgt_book");
            
            entity["mgt_name"] = book.Title;
            entity["mgt_author"] = book.Author;
            entity["mgt_description"] = book.Description;
            entity["mgt_rate"] = book.Rate;
            entity["mgt_datestarted"] = book.DateStart;
            entity["mgt_dateread"] = book.DateRead;
            book.Id = await client.CreateAsync(entity);
            return book;
        }


    }
}
