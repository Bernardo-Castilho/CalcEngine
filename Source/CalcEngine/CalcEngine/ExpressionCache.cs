using System;
using System.Collections.Generic;
using System.Text;

namespace CalcEngine
{
    /// <summary>
    /// Caches expressions based on their string representation.
    /// This saves parsing time.
    /// </summary>
    /// <remarks>
    /// Uses weak references to avoid accumulating unused expressions.
    /// </remarks>
    class ExpressionCache
    {
        Dictionary<string, WeakReference> _dct;
        CalcEngine _ce;
        int _hitCount;

        public ExpressionCache(CalcEngine ce)
        {
            _ce = ce;
            _dct = new Dictionary<string, WeakReference>();
        }

        // gets the parsed version of a string expression
        public Expression this[string expression]
        {
            get
            {
                Expression x = null;
                WeakReference wr;

                // get expression from cache
                if (_dct.TryGetValue(expression, out wr))
                {
                    x = wr.Target as Expression;
                }

                // if failed, parse now and store
                if (x == null)
                {
                    // remove all dead references from dictionary
                    if (_dct.Count > 100 && _hitCount++ > 100)
                    {
                        RemoveDeadReferences();
                        _hitCount = 0;
                    }

                    // store this expression
                    x = _ce.Parse(expression);
                    _dct[expression] = new WeakReference(x);
                }

                // return the parsed expression
                return x;
            }
        }

        // remove all dead references from the cache
        void RemoveDeadReferences()
        {
            for (bool done = false; !done; )
            {
                done = true;
                foreach (var k in _dct.Keys)
                {
                    if (!_dct[k].IsAlive)
                    {
                        _dct.Remove(k);
                        done = false;
                        break;
                    }
                }
            }
        }
    }
}
