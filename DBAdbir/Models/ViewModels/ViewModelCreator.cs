using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace DBAdbir.Models.ViewModels
{
    public static class ViewModelCreator
    {
        public static CategoryItemVM CreateCategoryItemVm(ICategoryRepository categoryRepository)
        {
            return new CategoryItemVM()
            {
                Item = new Item(),
                CategorySelectList = new SelectList(categoryRepository.Get(), "CategoryId", "Name", "Description")
            };
        }
    }
}
