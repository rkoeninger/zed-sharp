﻿using System;
using System.Threading;

namespace KitchenSink.Concurrent
{
    public class Stm
    {
        private readonly Mutex mutex = new Mutex(false);

        /// <summary>
        /// Creates a new Ref bound to this STM with the given
        /// initial value.
        /// </summary>
        public Ref<A> NewRef<A>(A initial) => new Ref<A>(this, initial);

        /// <summary>
        /// Opens a new Tran in this STM. Tran remains open until
        /// Commit or Rollback is called. Calls to BeginTran block
        /// until all previous Trans are complete.
        /// </summary>
        public Tran BeginTran(bool ambient = false)
        {
            mutex.WaitOne();
            return new Tran(mutex, ambient);
        }

        /// <summary>
        /// Invokes the given delegate inside an explicit Tran.
        /// </summary>
        public void InTran(Action<Tran> f)
        {
            using (var tran = BeginTran())
            {
                f(tran);
            }
        }

        /// <summary>
        /// Invokes the given delegate inside an ambient Tran.
        /// </summary>
        public void InTran(Action f)
        {
            using (BeginTran(true))
            {
                f();
            }
        }
    }
}