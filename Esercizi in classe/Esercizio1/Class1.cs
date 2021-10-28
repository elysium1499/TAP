using System;
using System.Collections.Generic;
using System.Linq;

namespace Esercizio1
{
    public class PagnationHelper<T>
    {
        // TODO: Complete this class

        private T[] myCollection;   //T è la rappresentazione di un valore non definito (in java var)-->var viene comunque usata
        private int pageSize;

        /// <summary>
        /// Constructor, takes in a list of items and the number of items that fit within a single page
        /// </summary>
        /// <param name="collection">A list of items</param>
        /// <param name="itemsPerPage">The number of items that fit within a single page</param>
        public PagnationHelper(IList<T> collection, int itemsPerPage)   //memorizzare questi elementi all'interno della classe
        {
            if (null == collection) throw new ArgumentNullException(nameof(collection));        //nameOf permette di stampare collection, esattamente come fare "collection"
            if (itemsPerPage <= 0) throw new ArgumentOutOfRangeException(nameof(itemsPerPage), "Page size must be positive");

            myCollection = collection.ToArray();                //toArray è una conversione da lista ad array
            pageSize = itemsPerPage;                            //assegnazione tipo java
        }

        /// <summary>
        /// The number of items within the collection
        /// </summary>
        public int ItemCount
        {
            get { return myCollection.Length; }       
            //get =>return myCollection.Length;    altro metodo per fare il return sopra, se seleziono sopra questa riga e guardo la lampadina viene mostrato il MIO codice in rosso
            // e il codice in verde che può essere una sostituzione del rosso
        }

        /// <summary>
        /// The number of pages
        /// </summary>
        public int PageCount
        {
            get
            {
                return ItemCount / pageSize + (ItemCount % pageSize == 0 ? 0 : 1);      
                //posso richiamare una funzione come fosse una variabile
            }
        }

        /// <summary>
        /// Returns the number of items in the page at the given page index 
        /// </summary>
        /// <param name="pageIndex">The zero-based page index to get the number of items for</param>
        /// <returns>The number of items on the specified page or -1 for pageIndex values that are out of range</returns>
        public int PageItemCount(int pageIndex)
        {
            if (pageIndex < 0 || pageIndex >= PageCount)
                return -1;
            if (pageIndex == PageCount-1 && (ItemCount % pageSize) != 0) return ItemCount % pageSize;
            return pageSize;
        }

        /// <summary>
        /// Returns the page index of the page containing the item at the given item index.
        /// </summary>
        /// <param name="itemIndex">The zero-based index of the item to get the pageIndex for</param>
        /// <returns>The zero-based page index of the page containing the item at the given item index or -1 if the item index is out of range</returns>
        public int PageIndex(int itemIndex)
        {
            if (itemIndex < 0 || itemIndex >= ItemCount) return -1;
            return itemIndex / pageSize;
        }
    }
}
