using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilteredCatalogDemo
{
    class FilteredCatalog : ComposablePartCatalog
    {

        private ComposablePartCatalog _source;
        private Func<ComposablePartDefinition, string, bool> _filter;

        public String Criteria { get; set; }
        public FilteredCatalog ( ComposablePartCatalog source, Func<ComposablePartDefinition, string, bool> filter )
        {
            this._source = source;
            this._filter = filter;
        }

        private IQueryable<ComposablePartDefinition> FilterCatalog ()
        {

            var results = from p in this._source.Parts
                          let keepPart = ( _filter ( p, this.Criteria ) )
                          where keepPart == true
                          select p;
            return results;
        }


        public override IQueryable<ComposablePartDefinition> Parts
        {
            get
            {
                return this.FilterCatalog ();
            }
        }

    }



    class FilteredCatalog2 : ComposablePartCatalog
    {

        private ComposablePartCatalog _source;
        private Func<ComposablePartDefinition, string, string, bool> _filter;

        public String Criteria { get; set; }
        public String Value { get; set; }
        public FilteredCatalog2 ( ComposablePartCatalog source, Func<ComposablePartDefinition, string, string, bool> filter )
        {
            this._source = source;
            this._filter = filter;
        }

        private IQueryable<ComposablePartDefinition> FilterCatalog ()
        {

            var results = from p in this._source.Parts
                          let keepPart = ( _filter ( p, this.Criteria, this.Value ) )
                          where keepPart == true
                          select p;
            return results;
        }


        public override IQueryable<ComposablePartDefinition> Parts
        {
            get
            {
                return this.FilterCatalog ();
            }
        }

    }
}
