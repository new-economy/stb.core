/*---------------------------------------------------------------------------------------------
 * Copyright (c) STB Chain. All rights reserved.
 * Licensed under the Source EULA. See License in the project root for license information.
 * Source code : https://github.com/stbchain
 * Website : http://www.soft2b.com/
 *---------------------------------------------------------------------------------------------
 ---------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;

namespace STB.Core
{
    public static class ClassExtensions
    {
        /// <summary>
        ///     ʵ�����Ϊ����ȡĬ��ֵ�Ĳ��� ԭ����obj==null?1:obj.Prop
        ///     �֣�obj.Get(c=>c.Prop)
        /// </summary>
        public static TResult GetProperty<TClass, TResult>(this TClass obj, Func<TClass, TResult> func)
            where TClass : class
        {
            if (obj == null) return default(TResult);
            return func(obj);
        }

        /// <summary>
        ///     ʵ�����ΪKey�����ڣ��򷵻�ValueĬ��ֵ
        ///     dict.ContainsKey(key)?dict[key]:0
        ///     ����ֱ��Ϊ dict.Get(key)����
        /// </summary>
        public static TResult GetProperty<TKey, TResult>(this IReadOnlyDictionary<TKey, TResult> dict, TKey key)
        {
            if (!dict.ContainsKey(key))
                return default(TResult);
            var obj = dict[key];
            return obj;
        }

        /// <summary>
        ///     ʵ�����ΪKey�����ڣ��򷵻�ValueĬ��ֵ
        ///     dict.ContainsKey(key)?dict[key].Id:0
        ///     ����ֱ��Ϊ dict.Get(key,c=>c.Id)����
        /// </summary>
        public static TResult GetProperty<TKey, TValue, TResult>(this IDictionary<TKey, TValue> dict, TKey key,
            Func<TValue, TResult> func)
        {
            if (!dict.ContainsKey(key))
                return default(TResult);
            var obj = dict[key];
            return func(obj);
        }
    }
}