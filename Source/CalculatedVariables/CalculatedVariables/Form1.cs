using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CalculatedVariables
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var ce = new CalcEngine.CalcEngine();
            var dct = new CalcDictionary(ce);
            ce.Variables = dct;
            
            dct["Amount"] = 12;
            dct["OfferPrice"] = 12.32;
            dct["Item1"] = "=Amount * OfferPrice";
            dct["Item2"] = "=Item1 * 0.06";

            // this will print "8.8704" 
            // (Amount * OfferPrice) * 0.06 = 12 * 12.32 * 0.06 = 8.8704
            Console.WriteLine(ce.Evaluate("Item2"));
        }
    }

    public class CalcDictionary : IDictionary<string, object>
    {
        CalcEngine.CalcEngine _ce;
        Dictionary<string, object> _dct;

        public CalcDictionary(CalcEngine.CalcEngine ce)
        {
            _ce = ce;
            _dct = new Dictionary<string, object>();
        }

        //---------------------------------------------------------------
        #region IDictionary<string,object> Members

        public void Add(string key, object value)
        {
            _dct.Add(key, value);
        }
        public bool ContainsKey(string key)
        {
            return _dct.ContainsKey(key);
        }
        public ICollection<string> Keys
        {
            get { return _dct.Keys; }
        }
        public bool Remove(string key)
        {
            return _dct.Remove(key);
        }
        public ICollection<object> Values
        {
            get { return _dct.Values; }
        }
        public bool TryGetValue(string key, out object value)
        {
            if (_dct.TryGetValue(key, out value))
            {
                var expr = value as string;
                if (expr != null && expr.Length > 0 && expr[0] == '=')
                {
                    value = _ce.Evaluate(expr.Substring(1));
                }
                return true;
            }
            return false;
        }
        public object this[string key]
        {
            get
            {
                object value;
                if (TryGetValue(key, out value))
                {
                    return value;
                }
                throw new Exception("invalid index");
            }
            set
            {
                _dct[key] = value;
            }
        }
        #endregion

        //---------------------------------------------------------------
        #region ICollection<KeyValuePair<string,object>> Members

        public void Add(KeyValuePair<string, object> item)
        {
            var d = _dct as ICollection<KeyValuePair<string, object>>;
            d.Add(item);
        }
        public void Clear()
        {
            _dct.Clear();
        }
        public bool Contains(KeyValuePair<string, object> item)
        {
            var d = _dct as ICollection<KeyValuePair<string, object>>;
            return d.Contains(item);
        }
        public void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
        {
            var d = _dct as ICollection<KeyValuePair<string, object>>;
            d.CopyTo(array, arrayIndex);
        }
        public int Count
        {
            get { return _dct.Count; }
        }
        public bool IsReadOnly
        {
            get { return false; }
        }
        public bool Remove(KeyValuePair<string, object> item)
        {
            var d = _dct as ICollection<KeyValuePair<string, object>>;
            return d.Remove(item);
        }
        #endregion

        //---------------------------------------------------------------
        #region IEnumerable<KeyValuePair<string,object>> Members

        public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
        {
            return _dct.GetEnumerator() as IEnumerator<KeyValuePair<string, object>>;
        }

        #endregion

        //---------------------------------------------------------------
        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _dct.GetEnumerator() as System.Collections.IEnumerator;
        }

        #endregion
    }
}
