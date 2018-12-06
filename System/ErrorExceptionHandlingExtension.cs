using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System
{
    public static class ErrorExceptionHandlingExtension
    {
        /// <summary>
        /// Adds try catch to an object.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="anonymousObjectType"></param>
        /// <param name="ExecuteAction"></param>
        public static void TryCatch<TSource>(this TSource anonymousObjectType, Action<TSource> ExecuteAction)
        {
            try
            {
                ExecuteAction(anonymousObjectType);
            }
            catch
            {
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="anonymousObjectType"></param>
        /// <param name="ExecuteAction"></param>
        public static void TryCatch<TSource>(this TSource anonymousObjectType, Action<TSource> ExecuteAction, Action<TSource> CatchAction)
        {
            try
            {
                ExecuteAction(anonymousObjectType);
            }
            catch
            {
                CatchAction(anonymousObjectType);
            }
        }

        /// <summary>
        /// Adds try catch to an object.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="anonymousObjectType"></param>
        /// <param name="ExecuteFunc"></param>
        /// <returns>returns the TResult type from the function. If fails returns an empty TResult.</returns>
        public static TResult TryCatch<TSource, TResult>(this TSource anonymousObjectType, Func<TSource, TResult> ExecuteFunc)
        {
            try
            {
                return ExecuteFunc(anonymousObjectType);
            }
            catch
            {
            }

            return default(TResult);
        }

        /// <summary>
        /// Adds try catch to an object.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="anonymousObjectType"></param>
        /// <param name="execAction"></param>
        /// <returns>returns the TResult type from the function. If fails returns an empty TResult.</returns>
        public static TResult TryCatch<TSource, TResult>(this TSource anonymousObjectType, Func<TSource, TResult> ExecuteFunc, Func<TSource, TResult> CatchcFunc)
        {
            try
            {
                return ExecuteFunc(anonymousObjectType);
            }
            catch
            {
                return CatchcFunc(anonymousObjectType);
            }
        }

        /// <summary>
        /// Adds try catch to an object. Also throws an exception if an exception occures.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="anonymousObjectType"></param>
        /// <param name="ExecuteAction"></param>
        public static void TryCatchThrow<TSource>(this TSource anonymousObjectType, Action<TSource> ExecuteAction)
        {
            try
            {
                ExecuteAction(anonymousObjectType);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Adds try catch to an object. Also throws an exception if an exception occures.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="anonymousObjectType"></param>
        /// <param name="ExecuteFunc"></param>
        /// <returns></returns>
        public static TResult TryCatchThrow<TSource, TResult>(this TSource anonymousObjectType, Func<TSource, TResult> ExecuteFunc)
        {
            try
            {
                return ExecuteFunc(anonymousObjectType);
            }
            catch
            {
                throw;
            }

        }

        /// <summary>
        /// Adds try catch to an object. Also throws an exception if an exception occures.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="anonymousObjectType"></param>
        /// <param name="ExecuteAction"></param>
        /// <param name="ExecuteFinally"></param>
        public static void TryCatchThrowFinally<TSource>(this TSource anonymousObjectType, Action<TSource> ExecuteAction, Action<TSource> ExecuteFinally)
        {
            try
            {
                ExecuteAction(anonymousObjectType);
            }
            catch
            {
                throw;
            }
            finally
            {
                ExecuteFinally(anonymousObjectType);
            }
        }

        /// <summary>
        /// Adds try catch to an object. Also throws an exception if an exception occures.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="anonymousObjectType"></param>
        /// <param name="ExecuteFunc"></param>
        /// <param name="ExecuteFinally"></param>
        /// <returns></returns>
        public static TResult TryCatchThrowFinally<TSource, TResult>(this TSource anonymousObjectType, Func<TSource, TResult> ExecuteFunc, Action<TSource> ExecuteFinally)
        {
            try
            {
                return ExecuteFunc(anonymousObjectType);
            }
            catch
            {
                throw;
            }
            finally
            {
                ExecuteFinally(anonymousObjectType);
            }
        }

        /// <summary>
        /// Adds try catch to an object.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="anonymousObjectType"></param>
        /// <param name="ExecuteAction"></param>
        /// <param name="ExecuteFinally"></param>
        public static void TryCatchFinally<TSource>(this TSource anonymousObjectType, Action<TSource> ExecuteAction, Action<TSource> ExecuteFinally)
        {
            try
            {
                ExecuteAction(anonymousObjectType);
            }
            catch
            {
            }
            finally
            {
                ExecuteFinally(anonymousObjectType);
            }
        }

        /// <summary>
        /// Adds try catch to an object.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="anonymousObjectType"></param>
        /// <param name="ExecuteFunc"></param>
        /// <param name="ExecuteFinally"></param>
        /// <returns></returns>
        public static TResult TryCatchFinally<TSource, TResult>(this TSource anonymousObjectType, Func<TSource, TResult> ExecuteFunc, Action<TSource> ExecuteFinally)
        {
            try
            {
                return ExecuteFunc(anonymousObjectType);
            }
            catch
            {
            }
            finally
            {
                ExecuteFinally(anonymousObjectType);
            }

            return default(TResult);
        }
    }
}
