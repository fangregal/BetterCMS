﻿using System.Collections.Generic;
using System.Linq;

using BetterCms.Core.DataContracts.Enums;
using BetterCms.Module.Api.Operations;
using BetterCms.Module.Root.ViewModels.Option;

namespace BetterCms.Module.Api.Extensions
{
    public static class OptionModelExtensions
    {
        public static IList<OptionViewModel> ToServiceModel(this IList<OptionModel> model)
        {
            return model
                .Select(o => new OptionViewModel
                    {
                        OptionDefaultValue = o.DefaultValue,
                        OptionKey = o.Key,
                        Type = (OptionType)(short)o.Type,
                        CustomOption = o.Type == Operations.Root.OptionType.Custom 
                            ? new CustomOptionViewModel {Identifier = o.CustomTypeIdentifier} 
                            : null
                    })
                .ToList();
        }
        
        public static IList<OptionValueEditViewModel> ToServiceModel(this IList<OptionValueModel> model)
        {
            return model
                .Select(o => new OptionValueEditViewModel
                    {
                        OptionDefaultValue = o.DefaultValue,
                        OptionKey = o.Key,
                        Type = (OptionType)(short)o.Type,
                        UseDefaultValue = o.UseDefaultValue,
                        OptionValue = o.Value,
                        CustomOption = o.Type == Operations.Root.OptionType.Custom 
                            ? new CustomOptionViewModel {Identifier = o.CustomTypeIdentifier} 
                            : null
                    })
                .ToList();
        }
    }
}