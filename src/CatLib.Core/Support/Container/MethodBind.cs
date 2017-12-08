﻿/*
 * This file is part of the CatLib package.
 *
 * (c) Yu Bin <support@catlib.io>
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 *
 * Document: http://catlib.io/
 */

using System.Reflection;

namespace CatLib
{
    /// <summary>
    /// 方法绑定数据
    /// </summary>
    internal sealed class MethodBind : Bindable<IMethodBind> , IMethodBind
    {
        /// <summary>
        /// 方法信息
        /// </summary>
        private readonly MethodInfo methodInfo;

        /// <summary>
        /// 方法信息
        /// </summary>
        public MethodInfo MethodInfo
        {
            get { return methodInfo; }
        }

        /// <summary>
        /// 调用目标
        /// </summary>
        private readonly object target;

        /// <summary>
        /// 调用目标
        /// </summary>
        public object Target
        {
            get { return target; }
        }

        /// <summary>
        /// 参数表
        /// </summary>
        private readonly ParameterInfo[] parameterInfos;

        /// <summary>
        /// 参数表
        /// </summary>
        public ParameterInfo[] ParameterInfos
        {
            get { return parameterInfos; }
        }

        /// <summary>
        /// 构建一个绑定数据
        /// </summary>
        /// <param name="container">依赖注入容器</param>
        /// <param name="service">服务名</param>
        /// <param name="target">调用目标</param>
        /// <param name="call">调用信息</param>
        public MethodBind(Container container, string service, object target, MethodInfo call)
            :base(container, service)
        {
            this.target = target;
            methodInfo = call;
            parameterInfos = methodInfo.GetParameters();
        }

        /// <summary>
        /// 解除绑定
        /// </summary>
        protected override void ReleaseBind()
        {
        }
    }
}