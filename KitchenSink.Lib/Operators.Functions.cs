﻿using System;
using System.Collections.Concurrent;

namespace KitchenSink
{
    public static partial class Operators
    {
        /// <summary>
        /// Forward function composition.
        /// </summary>
        public static Func<A, C> Compose<A, B, C>(
            Func<A, B> f,
            Func<B, C> g) =>
            x => g(f(x));

        /// <summary>
        /// Forward function composition.
        /// </summary>
        public static Func<A, D> Compose<A, B, C, D>(
            Func<A, B> f,
            Func<B, C> g,
            Func<C, D> h) =>
            x => h(g(f(x)));

        /// <summary>
        /// Forward function composition.
        /// </summary>
        public static Func<A, E> Compose<A, B, C, D, E>(
            Func<A, B> f,
            Func<B, C> g,
            Func<C, D> h,
            Func<D, E> i) =>
            x => i(h(g(f(x))));

        /// <summary>
        /// Forward function composition.
        /// </summary>
        public static Func<A, F> Compose<A, B, C, D, E, F>(
            Func<A, B> f,
            Func<B, C> g,
            Func<C, D> h,
            Func<D, E> i,
            Func<E, F> j) =>
            x => j(i(h(g(f(x)))));

        /// <summary>
        /// Function currying.
        /// </summary>
        public static Func<A, Func<B, C>> Curry<A, B, C>(
            Func<A, B, C> f) =>
            x => y => f(x, y);

        /// <summary>
        /// Function currying.
        /// </summary>
        public static Func<A, Func<B, Func<C, D>>> Curry<A, B, C, D>(
            Func<A, B, C, D> f) =>
            x => y => z => f(x, y, z);

        /// <summary>
        /// Function currying.
        /// </summary>
        public static Func<A, Func<B, Func<C, Func<D, E>>>> Curry<A, B, C, D, E>(
            Func<A, B, C, D, E> f) =>
            x => y => z => w => f(x, y, z, w);

        /// <summary>
        /// Function un-currying.
        /// </summary>
        public static Func<A, B, C> Uncurry<A, B, C>(
            Func<A, Func<B, C>> f) =>
            (x, y) => f(x)(y);

        /// <summary>
        /// Function un-currying.
        /// </summary>
        public static Func<A, B, C, D> Uncurry<A, B, C, D>(
            Func<A, Func<B, Func<C, D>>> f) =>
            (x, y, z) => f(x)(y)(z);

        /// <summary>
        /// Function un-currying.
        /// </summary>
        public static Func<A, B, C, D, E> Uncurry<A, B, C, D, E>(
            Func<A, Func<B, Func<C, Func<D, E>>>> f) =>
            (x, y, z, w) => f(x)(y)(z)(w);

        /// <summary>
        /// Join parameters into tuple.
        /// </summary>
        public static Func<(A, B), Z> Tuplize<A, B, Z>(Func<A, B, Z> f) =>
            t =>
            {
                var (a, b) = t;
                return f(a, b);
            };

        /// <summary>
        /// Join parameters into tuple.
        /// </summary>
        public static Func<(A, B, C), Z> Tuplize<A, B, C, Z>(Func<A, B, C, Z> f) =>
            t =>
            {
                var (a, b, c) = t;
                return f(a, b, c);
            };

        /// <summary>
        /// Join parameters into tuple.
        /// </summary>
        public static Func<(A, B, C, D), Z> Tuplize<A, B, C, D, Z>(Func<A, B, C, D, Z> f) =>
            t =>
            {
                var (a, b, c, d) = t;
                return f(a, b, c, d);
            };

        /// <summary>
        /// Split parameters from tuple.
        /// </summary>
        public static Func<A, B, Z> Detuplize<A, B, Z>(Func<(A, B), Z> f) =>
            (a, b) => f((a, b));

        /// <summary>
        /// Split parameters from tuple.
        /// </summary>
        public static Func<A, B, C, Z> Detuplize<A, B, C, Z>(Func<(A, B, C), Z> f) =>
            (a, b, c) => f((a, b, c));

        /// <summary>
        /// Split parameters from tuple.
        /// </summary>
        public static Func<A, B, C, D, Z> Detuplize<A, B, C, D, Z>(Func<(A, B, C, D), Z> f) =>
            (a, b, c, d) => f((a, b, c, d));

        /// <summary>
        /// Partially apply function.
        /// </summary>
        public static Func<B, Z> Apply<A, B, Z>(Func<A, B, Z> f, A a) =>
            b => f(a, b);

        /// <summary>
        /// Partially apply function.
        /// </summary>
        public static Func<B, C, Z> Apply<A, B, C, Z>(Func<A, B, C, Z> f, A a) =>
            (b, c) => f(a, b, c);

        /// <summary>
        /// Partially apply function.
        /// </summary>
        public static Func<C, Z> Apply<A, B, C, Z>(Func<A, B, C, Z> f, A a, B b) =>
            c => f(a, b, c);

        /// <summary>
        /// Partially apply function.
        /// </summary>
        public static Func<B, C, D, Z> Apply<A, B, C, D, Z>(Func<A, B, C, D, Z> f, A a) =>
            (b, c, d) => f(a, b, c, d);

        /// <summary>
        /// Partially apply function.
        /// </summary>
        public static Func<C, D, Z> Apply<A, B, C, D, Z>(Func<A, B, C, D, Z> f, A a, B b) =>
            (c, d) => f(a, b, c, d);

        /// <summary>
        /// Partially apply function.
        /// </summary>
        public static Func<D, Z> Apply<A, B, C, D, Z>(Func<A, B, C, D, Z> f, A a, B b, C c) =>
            d => f(a, b, c, d);

        /// <summary>
        /// Flip function arguments.
        /// </summary>
        public static Func<B, A, Z> Flip<A, B, Z>(Func<A, B, Z> f) =>
            (b, a) => f(a, b);

        /// <summary>
        /// Rotate function arguments forward.
        /// </summary>
        public static Func<C, A, B, Z> Rotate<A, B, C, Z>(Func<A, B, C, Z> f) =>
            (c, a, b) => f(a, b, c);

        /// <summary>
        /// Rotate function arguments backward.
        /// </summary>
        public static Func<B, C, A, Z> RotateBack<A, B, C, Z>(Func<A, B, C, Z> f) =>
            (b, c, a) => f(a, b, c);

        /// <summary>
        /// Wrap function with memoizing cache.
        /// </summary>
        public static Func<A, Z> Memo<A, Z>(Func<A, Z> f)
        {
            var cache = new ConcurrentDictionary<A, Z>();
            return a => cache.GetOrAdd(a, f);
        }

        /// <summary>
        /// Wrap function with memoizing cache.
        /// </summary>
        public static Func<A, B, Z> Memo<A, B, Z>(Func<A, B, Z> f)
        {
            var cache = new ConcurrentDictionary<(A, B), Z>();
            return (a, b) => cache.GetOrAdd((a, b), Tuplize(f));
        }

        /// <summary>
        /// Wrap function with memoizing cache.
        /// </summary>
        public static Func<A, B, C, Z> Memo<A, B, C, Z>(Func<A, B, C, Z> f)
        {
            var cache = new ConcurrentDictionary<(A, B, C), Z>();
            return (a, b, c) => cache.GetOrAdd((a, b, c), Tuplize(f));
        }

        /// <summary>
        /// Wrap function with memoizing cache.
        /// </summary>
        public static Func<A, B, C, D, Z> Memo<A, B, C, D, Z>(Func<A, B, C, D, Z> f)
        {
            var cache = new ConcurrentDictionary<(A, B, C, D), Z>();
            return (a, b, c, d) => cache.GetOrAdd((a, b, c, d), Tuplize(f));
        }

        /// <summary>
        /// Wrap function with memoizing cache with an expiration timeout.
        /// </summary>
        public static Func<Z> Memo<Z>(TimeSpan timeout, Func<Z> f)
        {
            var cache = new ConcurrentDictionary<int, (DateTime, Z)>();
            return () => cache.AddOrUpdate(
                0,
                _ => (DateTime.UtcNow, f()),
                (_, current) => DateTime.UtcNow - current.Item1 > timeout
                    ? (DateTime.UtcNow, f())
                    : current).Item2;
        }

        /// <summary>
        /// Wrap function with memoizing cache with an expiration timeout.
        /// </summary>
        public static Func<A, Z> Memo<A, Z>(TimeSpan timeout, Func<A, Z> f)
        {
            var cache = new ConcurrentDictionary<A, (DateTime, Z)>();
            return a => cache.AddOrUpdate(
                a,
                _ => (DateTime.UtcNow, f(a)),
                (_, current) => DateTime.UtcNow - current.Item1 > timeout
                    ? (DateTime.UtcNow, f(a))
                    : current).Item2;
        }

        /// <summary>
        /// Wrap function with memoizing cache with an expiration timeout.
        /// </summary>
        public static Func<A, B, Z> Memo<A, B, Z>(TimeSpan timeout, Func<A, B, Z> f)
        {
            var cache = new ConcurrentDictionary<(A, B), (DateTime, Z)>();
            return (a, b) => cache.AddOrUpdate(
                (a, b),
                _ => (DateTime.UtcNow, f(a, b)),
                (_, current) => DateTime.UtcNow - current.Item1 > timeout
                    ? (DateTime.UtcNow, f(a, b))
                    : current).Item2;
        }

        /// <summary>
        /// Wrap function with memoizing cache with an expiration timeout.
        /// </summary>
        public static Func<A, B, C, Z> Memo<A, B, C, Z>(TimeSpan timeout, Func<A, B, C, Z> f)
        {
            var cache = new ConcurrentDictionary<(A, B, C), (DateTime, Z)>();
            return (a, b, c) => cache.AddOrUpdate(
                (a, b, c),
                _ => (DateTime.UtcNow, f(a, b, c)),
                (_, current) => DateTime.UtcNow - current.Item1 > timeout
                    ? (DateTime.UtcNow, f(a, b, c))
                    : current).Item2;
        }

        /// <summary>
        /// Wrap function with memoizing cache with an expiration timeout.
        /// </summary>
        public static Func<A, B, C, D, Z> Memo<A, B, C, D, Z>(TimeSpan timeout, Func<A, B, C, D, Z> f)
        {
            var cache = new ConcurrentDictionary<(A, B, C, D), (DateTime, Z)>();
            return (a, b, c, d) => cache.AddOrUpdate(
                (a, b, c, d),
                _ => (DateTime.UtcNow, f(a, b, c, d)),
                (_, current) => DateTime.UtcNow - current.Item1 > timeout
                    ? (DateTime.UtcNow, f(a, b, c, d))
                    : current).Item2;
        }
    }
}
