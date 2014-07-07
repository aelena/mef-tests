using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicePluginDemo
{

    class GlobalConstants
    {
        public const string SEARCH_PROVIDER = "SearchProvider";
        public const string WRITE_PROVIDER = "WriteProvider";
        public const string APPLICATION_ID = "ApplicationID";
        public const string APP_ONE = "AppOne";
        public const string APP_TWO = "AppTwo";

    }

    class ServiceProvider
    {

        // this hypothetical searchProviders list keeps a list of possible implementations
        [ImportMany ( GlobalConstants.SEARCH_PROVIDER )]
        internal IList<IDemoInterface> SearchProviders;
        // same for classes who will write data to the backend
        [ImportMany ( GlobalConstants.WRITE_PROVIDER )]
        internal IList<IDemoInterface> DataWriterServices;

        public ServiceProvider ()
        {
            this.SearchProviders = new List<IDemoInterface> ();
            this.DataWriterServices = new List<IDemoInterface> ();
        }

        public IEnumerable<string> Search ( int providerID )
        {
            return this.SearchProviders [ providerID ].Search ( "gad" );
        }

        public Tuple<bool, string> Write ( int providerID, object obj )
        {
            return this.DataWriterServices [ providerID ].WriteToDataStore ( obj );
        }
    }



    /*
     * these must be exported as interfaces, otherwise 
     * the exports would be the concrete implementations
     * but we want a list of possible interface
     * implementations that is unknown before hand
     */

    [Export ( GlobalConstants.SEARCH_PROVIDER, typeof ( IDemoInterface ) )]
    [ExportMetadata ( GlobalConstants.APPLICATION_ID, GlobalConstants.APP_ONE )]
    class Provider1 : IDemoInterface
    {

        #region IDemoInterface Members

        public IEnumerable<string> Search ( string filter )
        {
            return new List<string>{
                "data returned from Provider 1",
                "yet more data...",
                "finally, some more useless data"
            };

        }

        public Tuple<bool, string> WriteToDataStore ( object data )
        {
            if ( data == null )
                return new Tuple<bool, string> ( false, "Provider1 error: no data to be saved" );
            else
                return new Tuple<bool, string> ( true, "Data was successfully saved by Provider1 class" );
        }

        #endregion
    }

    [Export ( GlobalConstants.SEARCH_PROVIDER, typeof ( IDemoInterface ) )]
    [ExportMetadata ( GlobalConstants.APPLICATION_ID, GlobalConstants.APP_TWO )]
    class Provider3 : IDemoInterface
    {

        #region IDemoInterface Members

        public IEnumerable<string> Search ( string filter )
        {
            return new List<string>{
                "data returned from Provider 3",
                "yadda yadda blah blah"
            };

        }

        public Tuple<bool, string> WriteToDataStore ( object data )
        {
            if ( data == null )
                return new Tuple<bool, string> ( false, "Provider1 error: no data to be saved" );
            else
                return new Tuple<bool, string> ( true, "Data was successfully saved by Provider1 class" );
        }

        #endregion

    }

    [Export ( GlobalConstants.WRITE_PROVIDER, typeof ( IDemoInterface ) )]
    [ExportMetadata ( GlobalConstants.APPLICATION_ID, GlobalConstants.APP_ONE )]
    class Provider2 : IDemoInterface
    {

        #region IDemoInterface Members

        public IEnumerable<string> Search ( string filter )
        {
            return new List<string>{
                "data returned from Provider 2",
                "come hell or high water....it's time we do somethign here",
                "the answer to life is 42"
            };

        }

        public Tuple<bool, string> WriteToDataStore ( object data )
        {
            if ( data == null )
                return new Tuple<bool, string> ( false, "Provider2 error: no data to be saved" );
            else
                return new Tuple<bool, string> ( true, "Data was successfully saved by Provider2 class" );
        }

        #endregion
    }

    [Export ( GlobalConstants.WRITE_PROVIDER, typeof ( IDemoInterface ) )]
    [ExportMetadata ( GlobalConstants.APPLICATION_ID, GlobalConstants.APP_TWO )]
    class Provider4 : IDemoInterface
    {

        #region IDemoInterface Members

        public IEnumerable<string> Search ( string filter )
        {
            return new List<string>{
                "data returned from Provider 2",
                "come hell or high water....it's time we do somethign here",
                "the answer to life is 42"
            };

        }

        public Tuple<bool, string> WriteToDataStore ( object data )
        {
            return new Tuple<bool, string> ( true, "Data was successfully saved by Provider4 class (I'll swallow anyting" );
        }

        #endregion
    }

}
