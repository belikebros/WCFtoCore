
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace WCFService.DataAccessLayer
{
    public class tbl_userFilesCollection
    {

        public int FileId { get; set; }

        public Nullable<int> UserId { get; set; }

        public byte[] FileData { get; set; }

        public string FileName { get; set; }

        public Nullable<int> FileSize { get; set; }

        public string FileContentType { get; set; }

        public string FileExtension { get; set; }

        public virtual tbl_userLoginDetails tbl_userLoginDetails { get; set; }
    }
}
