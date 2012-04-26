using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Raven.Abstractions.Indexing;
using Raven.Client.Indexes;

namespace ScrumR.Tests.Persistance 
{
    public class BacklogItems_FullTextSearchOnStory : AbstractIndexCreationTask<BacklogItem>
    {
        public BacklogItems_FullTextSearchOnStory()
        {
            Map = backlogitems => from backlogItem in backlogitems
                                  select new { backlogItem.Story };
            
            Index(x => x.Story, FieldIndexing.Analyzed);

            // todo: add custom analyser for this index
        }

        public class Result
        {
            public string Story { get; set; }
        }
    }
}