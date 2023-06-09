﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MO_Lambda.Models
{
    public class ATTRIBUTE_BLIBLI_AND_OPT
    {
        public List<ATTRIBUTE_BLIBLI_NEW> attributes { get; set; } = new List<ATTRIBUTE_BLIBLI_NEW>();
        public List<ATTRIBUTE_OPT_BLIBLI> attribute_opt { get; set; } = new List<ATTRIBUTE_OPT_BLIBLI>();
    }

    //add by nurul 11/5/2021, limit blibli
    public class ATTRIBUTE_BLIBLI_AND_OPT_New
    {
        public List<ATTRIBUTE_BLIBLI> attributes { get; set; } = new List<ATTRIBUTE_BLIBLI>();
        public List<ATTRIBUTE_OPT_BLIBLI> attribute_opt { get; set; } = new List<ATTRIBUTE_OPT_BLIBLI>();
    }
    //end add by nurul 11/5/2021, limit blibli

    [Table("ATTRIBUTE_BLIBLI")]
    public class ATTRIBUTE_BLIBLI
    {
        public object this[string propertyName]
        {
            get
            {
                // probably faster without reflection:
                // like:  return Properties.Settings.Default.PropertyValues[propertyName] 
                // instead of the following
                Type myType = typeof(ATTRIBUTE_BLIBLI);
                System.Reflection.PropertyInfo myPropInfo = myType.GetProperty(propertyName);
                return myPropInfo.GetValue(this, null);
            }
            set
            {
                Type myType = typeof(ATTRIBUTE_BLIBLI);
                System.Reflection.PropertyInfo myPropInfo = myType.GetProperty(propertyName);
                myPropInfo.SetValue(this, value, null);

            }

        }

        [StringLength(50)]
        public string CATEGORY_CODE { get; set; }
        [StringLength(250)]
        public string CATEGORY_NAME { get; set; }
        [StringLength(50)]
        public string ACODE_1 { get; set; }
        [StringLength(50)]
        public string ATYPE_1 { get; set; }
        [StringLength(250)]
        public string ANAME_1 { get; set; }
        [StringLength(1)]
        public string AOPTIONS_1 { get; set; }
        [StringLength(1)]
        public string AMANDATORY_1 { get; set; }
        [StringLength(1)]
        public string AVARCREATE_1 { get; set; }
        [StringLength(1)]
        public string ASKUVALUE_1 { get; set; }
        [StringLength(50)]
        public string ACODE_2 { get; set; }
        [StringLength(50)]
        public string ATYPE_2 { get; set; }
        [StringLength(250)]
        public string ANAME_2 { get; set; }
        [StringLength(1)]
        public string AOPTIONS_2 { get; set; }
        [StringLength(1)]
        public string AMANDATORY_2 { get; set; }
        [StringLength(1)]
        public string AVARCREATE_2 { get; set; }
        [StringLength(1)]
        public string ASKUVALUE_2 { get; set; }
        [StringLength(50)]
        public string ACODE_3 { get; set; }
        [StringLength(50)]
        public string ATYPE_3 { get; set; }
        [StringLength(250)]
        public string ANAME_3 { get; set; }
        [StringLength(1)]
        public string AOPTIONS_3 { get; set; }
        [StringLength(1)]
        public string AMANDATORY_3 { get; set; }
        [StringLength(1)]
        public string AVARCREATE_3 { get; set; }
        [StringLength(1)]
        public string ASKUVALUE_3 { get; set; }
        [StringLength(50)]
        public string ACODE_4 { get; set; }
        [StringLength(50)]
        public string ATYPE_4 { get; set; }
        [StringLength(250)]
        public string ANAME_4 { get; set; }
        [StringLength(1)]
        public string AOPTIONS_4 { get; set; }
        [StringLength(1)]
        public string AMANDATORY_4 { get; set; }
        [StringLength(1)]
        public string AVARCREATE_4 { get; set; }
        [StringLength(1)]
        public string ASKUVALUE_4 { get; set; }
        [StringLength(50)]
        public string ACODE_5 { get; set; }
        [StringLength(50)]
        public string ATYPE_5 { get; set; }
        [StringLength(250)]
        public string ANAME_5 { get; set; }
        [StringLength(1)]
        public string AOPTIONS_5 { get; set; }
        [StringLength(1)]
        public string AMANDATORY_5 { get; set; }
        [StringLength(1)]
        public string AVARCREATE_5 { get; set; }
        [StringLength(1)]
        public string ASKUVALUE_5 { get; set; }
        [StringLength(50)]
        public string ACODE_6 { get; set; }
        [StringLength(50)]
        public string ATYPE_6 { get; set; }
        [StringLength(250)]
        public string ANAME_6 { get; set; }
        [StringLength(1)]
        public string AOPTIONS_6 { get; set; }
        [StringLength(1)]
        public string AMANDATORY_6 { get; set; }
        [StringLength(1)]
        public string AVARCREATE_6 { get; set; }
        [StringLength(1)]
        public string ASKUVALUE_6 { get; set; }
        [StringLength(50)]
        public string ACODE_7 { get; set; }
        [StringLength(50)]
        public string ATYPE_7 { get; set; }
        [StringLength(250)]
        public string ANAME_7 { get; set; }
        [StringLength(1)]
        public string AOPTIONS_7 { get; set; }
        [StringLength(1)]
        public string AMANDATORY_7 { get; set; }
        [StringLength(1)]
        public string AVARCREATE_7 { get; set; }
        [StringLength(1)]
        public string ASKUVALUE_7 { get; set; }
        [StringLength(50)]
        public string ACODE_8 { get; set; }
        [StringLength(50)]
        public string ATYPE_8 { get; set; }
        [StringLength(250)]
        public string ANAME_8 { get; set; }
        [StringLength(1)]
        public string AOPTIONS_8 { get; set; }
        [StringLength(1)]
        public string AMANDATORY_8 { get; set; }
        [StringLength(1)]
        public string AVARCREATE_8 { get; set; }
        [StringLength(1)]
        public string ASKUVALUE_8 { get; set; }
        [StringLength(50)]
        public string ACODE_9 { get; set; }
        [StringLength(50)]
        public string ATYPE_9 { get; set; }
        [StringLength(250)]
        public string ANAME_9 { get; set; }
        [StringLength(1)]
        public string AOPTIONS_9 { get; set; }
        [StringLength(1)]
        public string AMANDATORY_9 { get; set; }
        [StringLength(1)]
        public string AVARCREATE_9 { get; set; }
        [StringLength(1)]
        public string ASKUVALUE_9 { get; set; }
        [StringLength(50)]
        public string ACODE_10 { get; set; }
        [StringLength(50)]
        public string ATYPE_10 { get; set; }
        [StringLength(250)]
        public string ANAME_10 { get; set; }
        [StringLength(1)]
        public string AOPTIONS_10 { get; set; }
        [StringLength(1)]
        public string AMANDATORY_10 { get; set; }
        [StringLength(1)]
        public string AVARCREATE_10 { get; set; }
        [StringLength(1)]
        public string ASKUVALUE_10 { get; set; }
        [StringLength(50)]
        public string ACODE_11 { get; set; }
        [StringLength(50)]
        public string ATYPE_11 { get; set; }
        [StringLength(250)]
        public string ANAME_11 { get; set; }
        [StringLength(1)]
        public string AOPTIONS_11 { get; set; }
        [StringLength(1)]
        public string AMANDATORY_11 { get; set; }
        [StringLength(1)]
        public string AVARCREATE_11 { get; set; }
        [StringLength(1)]
        public string ASKUVALUE_11 { get; set; }
        [StringLength(50)]
        public string ACODE_12 { get; set; }
        [StringLength(50)]
        public string ATYPE_12 { get; set; }
        [StringLength(250)]
        public string ANAME_12 { get; set; }
        [StringLength(1)]
        public string AOPTIONS_12 { get; set; }
        [StringLength(1)]
        public string AMANDATORY_12 { get; set; }
        [StringLength(1)]
        public string AVARCREATE_12 { get; set; }
        [StringLength(1)]
        public string ASKUVALUE_12 { get; set; }
        [StringLength(50)]
        public string ACODE_13 { get; set; }
        [StringLength(50)]
        public string ATYPE_13 { get; set; }
        [StringLength(250)]
        public string ANAME_13 { get; set; }
        [StringLength(1)]
        public string AOPTIONS_13 { get; set; }
        [StringLength(1)]
        public string AMANDATORY_13 { get; set; }
        [StringLength(1)]
        public string AVARCREATE_13 { get; set; }
        [StringLength(1)]
        public string ASKUVALUE_13 { get; set; }
        [StringLength(50)]
        public string ACODE_14 { get; set; }
        [StringLength(50)]
        public string ATYPE_14 { get; set; }
        [StringLength(250)]
        public string ANAME_14 { get; set; }
        [StringLength(1)]
        public string AOPTIONS_14 { get; set; }
        [StringLength(1)]
        public string AMANDATORY_14 { get; set; }
        [StringLength(1)]
        public string AVARCREATE_14 { get; set; }
        [StringLength(1)]
        public string ASKUVALUE_14 { get; set; }
        [StringLength(50)]
        public string ACODE_15 { get; set; }
        [StringLength(50)]
        public string ATYPE_15 { get; set; }
        [StringLength(250)]
        public string ANAME_15 { get; set; }
        [StringLength(1)]
        public string AOPTIONS_15 { get; set; }
        [StringLength(1)]
        public string AMANDATORY_15 { get; set; }
        [StringLength(1)]
        public string AVARCREATE_15 { get; set; }
        [StringLength(1)]
        public string ASKUVALUE_15 { get; set; }
        [StringLength(50)]
        public string ACODE_16 { get; set; }
        [StringLength(50)]
        public string ATYPE_16 { get; set; }
        [StringLength(250)]
        public string ANAME_16 { get; set; }
        [StringLength(1)]
        public string AOPTIONS_16 { get; set; }
        [StringLength(1)]
        public string AMANDATORY_16 { get; set; }
        [StringLength(1)]
        public string AVARCREATE_16 { get; set; }
        [StringLength(1)]
        public string ASKUVALUE_16 { get; set; }
        [StringLength(50)]
        public string ACODE_17 { get; set; }
        [StringLength(50)]
        public string ATYPE_17 { get; set; }
        [StringLength(250)]
        public string ANAME_17 { get; set; }
        [StringLength(1)]
        public string AOPTIONS_17 { get; set; }
        [StringLength(1)]
        public string AMANDATORY_17 { get; set; }
        [StringLength(1)]
        public string AVARCREATE_17 { get; set; }
        [StringLength(1)]
        public string ASKUVALUE_17 { get; set; }
        [StringLength(50)]
        public string ACODE_18 { get; set; }
        [StringLength(50)]
        public string ATYPE_18 { get; set; }
        [StringLength(250)]
        public string ANAME_18 { get; set; }
        [StringLength(1)]
        public string AOPTIONS_18 { get; set; }
        [StringLength(1)]
        public string AMANDATORY_18 { get; set; }
        [StringLength(1)]
        public string AVARCREATE_18 { get; set; }
        [StringLength(1)]
        public string ASKUVALUE_18 { get; set; }
        [StringLength(50)]
        public string ACODE_19 { get; set; }
        [StringLength(50)]
        public string ATYPE_19 { get; set; }
        [StringLength(250)]
        public string ANAME_19 { get; set; }
        [StringLength(1)]
        public string AOPTIONS_19 { get; set; }
        [StringLength(1)]
        public string AMANDATORY_19 { get; set; }
        [StringLength(1)]
        public string AVARCREATE_19 { get; set; }
        [StringLength(1)]
        public string ASKUVALUE_19 { get; set; }
        [StringLength(50)]
        public string ACODE_20 { get; set; }
        [StringLength(50)]
        public string ATYPE_20 { get; set; }
        [StringLength(250)]
        public string ANAME_20 { get; set; }
        [StringLength(1)]
        public string AOPTIONS_20 { get; set; }
        [StringLength(1)]
        public string AMANDATORY_20 { get; set; }
        [StringLength(1)]
        public string AVARCREATE_20 { get; set; }
        [StringLength(1)]
        public string ASKUVALUE_20 { get; set; }
        [StringLength(50)]
        public string ACODE_21 { get; set; }
        [StringLength(50)]
        public string ATYPE_21 { get; set; }
        [StringLength(250)]
        public string ANAME_21 { get; set; }
        [StringLength(1)]
        public string AOPTIONS_21 { get; set; }
        [StringLength(1)]
        public string AMANDATORY_21 { get; set; }
        [StringLength(1)]
        public string AVARCREATE_21 { get; set; }
        [StringLength(1)]
        public string ASKUVALUE_21 { get; set; }
        [StringLength(50)]
        public string ACODE_22 { get; set; }
        [StringLength(50)]
        public string ATYPE_22 { get; set; }
        [StringLength(250)]
        public string ANAME_22 { get; set; }
        [StringLength(1)]
        public string AOPTIONS_22 { get; set; }
        [StringLength(1)]
        public string AMANDATORY_22 { get; set; }
        [StringLength(1)]
        public string AVARCREATE_22 { get; set; }
        [StringLength(1)]
        public string ASKUVALUE_22 { get; set; }
        [StringLength(50)]
        public string ACODE_23 { get; set; }
        [StringLength(50)]
        public string ATYPE_23 { get; set; }
        [StringLength(250)]
        public string ANAME_23 { get; set; }
        [StringLength(1)]
        public string AOPTIONS_23 { get; set; }
        [StringLength(1)]
        public string AMANDATORY_23 { get; set; }
        [StringLength(1)]
        public string AVARCREATE_23 { get; set; }
        [StringLength(1)]
        public string ASKUVALUE_23 { get; set; }
        [StringLength(50)]
        public string ACODE_24 { get; set; }
        [StringLength(50)]
        public string ATYPE_24 { get; set; }
        [StringLength(250)]
        public string ANAME_24 { get; set; }
        [StringLength(1)]
        public string AOPTIONS_24 { get; set; }
        [StringLength(1)]
        public string AMANDATORY_24 { get; set; }
        [StringLength(1)]
        public string AVARCREATE_24 { get; set; }
        [StringLength(1)]
        public string ASKUVALUE_24 { get; set; }
        [StringLength(50)]
        public string ACODE_25 { get; set; }
        [StringLength(50)]
        public string ATYPE_25 { get; set; }
        [StringLength(250)]
        public string ANAME_25 { get; set; }
        [StringLength(1)]
        public string AOPTIONS_25 { get; set; }
        [StringLength(1)]
        public string AMANDATORY_25 { get; set; }
        [StringLength(1)]
        public string AVARCREATE_25 { get; set; }
        [StringLength(1)]
        public string ASKUVALUE_25 { get; set; }
        [StringLength(50)]
        public string ACODE_26 { get; set; }
        [StringLength(50)]
        public string ATYPE_26 { get; set; }
        [StringLength(250)]
        public string ANAME_26 { get; set; }
        [StringLength(1)]
        public string AOPTIONS_26 { get; set; }
        [StringLength(1)]
        public string AMANDATORY_26 { get; set; }
        [StringLength(1)]
        public string AVARCREATE_26 { get; set; }
        [StringLength(1)]
        public string ASKUVALUE_26 { get; set; }
        [StringLength(50)]
        public string ACODE_27 { get; set; }
        [StringLength(50)]
        public string ATYPE_27 { get; set; }
        [StringLength(250)]
        public string ANAME_27 { get; set; }
        [StringLength(1)]
        public string AOPTIONS_27 { get; set; }
        [StringLength(1)]
        public string AMANDATORY_27 { get; set; }
        [StringLength(1)]
        public string AVARCREATE_27 { get; set; }
        [StringLength(1)]
        public string ASKUVALUE_27 { get; set; }
        [StringLength(50)]
        public string ACODE_28 { get; set; }
        [StringLength(50)]
        public string ATYPE_28 { get; set; }
        [StringLength(250)]
        public string ANAME_28 { get; set; }
        [StringLength(1)]
        public string AOPTIONS_28 { get; set; }
        [StringLength(1)]
        public string AMANDATORY_28 { get; set; }
        [StringLength(1)]
        public string AVARCREATE_28 { get; set; }
        [StringLength(1)]
        public string ASKUVALUE_28 { get; set; }
        [StringLength(50)]
        public string ACODE_29 { get; set; }
        [StringLength(50)]
        public string ATYPE_29 { get; set; }
        [StringLength(250)]
        public string ANAME_29 { get; set; }
        [StringLength(1)]
        public string AOPTIONS_29 { get; set; }
        [StringLength(1)]
        public string AMANDATORY_29 { get; set; }
        [StringLength(1)]
        public string AVARCREATE_29 { get; set; }
        [StringLength(1)]
        public string ASKUVALUE_29 { get; set; }
        [StringLength(50)]
        public string ACODE_30 { get; set; }
        [StringLength(50)]
        public string ATYPE_30 { get; set; }
        [StringLength(250)]
        public string ANAME_30 { get; set; }
        [StringLength(1)]
        public string AOPTIONS_30 { get; set; }
        [StringLength(1)]
        public string AMANDATORY_30 { get; set; }
        [StringLength(1)]
        public string AVARCREATE_30 { get; set; }
        [StringLength(1)]
        public string ASKUVALUE_30 { get; set; }
        [StringLength(50)]
        public string ACODE_31 { get; set; }
        [StringLength(50)]
        public string ATYPE_31 { get; set; }
        [StringLength(250)]
        public string ANAME_31 { get; set; }
        [StringLength(1)]
        public string AOPTIONS_31 { get; set; }
        [StringLength(1)]
        public string AMANDATORY_31 { get; set; }
        [StringLength(1)]
        public string AVARCREATE_31 { get; set; }
        [StringLength(1)]
        public string ASKUVALUE_31 { get; set; }
        [StringLength(50)]
        public string ACODE_32 { get; set; }
        [StringLength(50)]
        public string ATYPE_32 { get; set; }
        [StringLength(250)]
        public string ANAME_32 { get; set; }
        [StringLength(1)]
        public string AOPTIONS_32 { get; set; }
        [StringLength(1)]
        public string AMANDATORY_32 { get; set; }
        [StringLength(1)]
        public string AVARCREATE_32 { get; set; }
        [StringLength(1)]
        public string ASKUVALUE_32 { get; set; }
        [StringLength(50)]
        public string ACODE_33 { get; set; }
        [StringLength(50)]
        public string ATYPE_33 { get; set; }
        [StringLength(250)]
        public string ANAME_33 { get; set; }
        [StringLength(1)]
        public string AOPTIONS_33 { get; set; }
        [StringLength(1)]
        public string AMANDATORY_33 { get; set; }
        [StringLength(1)]
        public string AVARCREATE_33 { get; set; }
        [StringLength(1)]
        public string ASKUVALUE_33 { get; set; }
        [StringLength(50)]
        public string ACODE_34 { get; set; }
        [StringLength(50)]
        public string ATYPE_34 { get; set; }
        [StringLength(250)]
        public string ANAME_34 { get; set; }
        [StringLength(1)]
        public string AOPTIONS_34 { get; set; }
        [StringLength(1)]
        public string AMANDATORY_34 { get; set; }
        [StringLength(1)]
        public string AVARCREATE_34 { get; set; }
        [StringLength(1)]
        public string ASKUVALUE_34 { get; set; }
        [StringLength(50)]
        public string ACODE_35 { get; set; }
        [StringLength(50)]
        public string ATYPE_35 { get; set; }
        [StringLength(250)]
        public string ANAME_35 { get; set; }
        [StringLength(1)]
        public string AOPTIONS_35 { get; set; }
        [StringLength(1)]
        public string AMANDATORY_35 { get; set; }
        [StringLength(1)]
        public string AVARCREATE_35 { get; set; }
        [StringLength(1)]
        public string ASKUVALUE_35 { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? RecNum { get; set; }
    }

    public class ATTRIBUTE_BLIBLI_NEW
    {
        public object this[string propertyName]
        {
            get
            {
                // probably faster without reflection:
                // like:  return Properties.Settings.Default.PropertyValues[propertyName] 
                // instead of the following
                Type myType = typeof(ATTRIBUTE_BLIBLI_NEW);
                System.Reflection.PropertyInfo myPropInfo = myType.GetProperty(propertyName);
                return myPropInfo.GetValue(this, null);
            }
            set
            {
                Type myType = typeof(ATTRIBUTE_BLIBLI_NEW);
                System.Reflection.PropertyInfo myPropInfo = myType.GetProperty(propertyName);
                myPropInfo.SetValue(this, value, null);

            }

        }

        [StringLength(50)]
        public string CATEGORY_CODE { get; set; }
        [StringLength(250)]
        public string CATEGORY_NAME { get; set; }
        [StringLength(50)]
        public string ACODE_1 { get; set; }
        [StringLength(50)]
        public string ATYPE_1 { get; set; }
        [StringLength(250)]
        public string ANAME_1 { get; set; }
        [StringLength(1)]
        public string AOPTIONS_1 { get; set; }
        public string AMANDATORY_1 { get; set; }
        public string AVARCREATE_1 { get; set; }
        [StringLength(50)]
        public string ACODE_2 { get; set; }
        [StringLength(50)]
        public string ATYPE_2 { get; set; }
        [StringLength(250)]
        public string ANAME_2 { get; set; }
        [StringLength(1)]
        public string AOPTIONS_2 { get; set; }
        public string AMANDATORY_2 { get; set; }
        public string AVARCREATE_2 { get; set; }
        [StringLength(50)]
        public string ACODE_3 { get; set; }
        [StringLength(50)]
        public string ATYPE_3 { get; set; }
        [StringLength(250)]
        public string ANAME_3 { get; set; }
        [StringLength(1)]
        public string AOPTIONS_3 { get; set; }
        public string AMANDATORY_3 { get; set; }
        public string AVARCREATE_3 { get; set; }
        [StringLength(50)]
        public string ACODE_4 { get; set; }
        [StringLength(50)]
        public string ATYPE_4 { get; set; }
        [StringLength(250)]
        public string ANAME_4 { get; set; }
        [StringLength(1)]
        public string AOPTIONS_4 { get; set; }
        public string AMANDATORY_4 { get; set; }
        public string AVARCREATE_4 { get; set; }
        [StringLength(50)]
        public string ACODE_5 { get; set; }
        [StringLength(50)]
        public string ATYPE_5 { get; set; }
        [StringLength(250)]
        public string ANAME_5 { get; set; }
        [StringLength(1)]
        public string AOPTIONS_5 { get; set; }
        public string AMANDATORY_5 { get; set; }
        public string AVARCREATE_5 { get; set; }
        [StringLength(50)]
        public string ACODE_6 { get; set; }
        [StringLength(50)]
        public string ATYPE_6 { get; set; }
        [StringLength(250)]
        public string ANAME_6 { get; set; }
        [StringLength(1)]
        public string AOPTIONS_6 { get; set; }
        public string AMANDATORY_6 { get; set; }
        public string AVARCREATE_6 { get; set; }
        [StringLength(50)]
        public string ACODE_7 { get; set; }
        [StringLength(50)]
        public string ATYPE_7 { get; set; }
        [StringLength(250)]
        public string ANAME_7 { get; set; }
        [StringLength(1)]
        public string AOPTIONS_7 { get; set; }
        public string AMANDATORY_7 { get; set; }
        public string AVARCREATE_7 { get; set; }
        [StringLength(50)]
        public string ACODE_8 { get; set; }
        [StringLength(50)]
        public string ATYPE_8 { get; set; }
        [StringLength(250)]
        public string ANAME_8 { get; set; }
        [StringLength(1)]
        public string AOPTIONS_8 { get; set; }
        public string AMANDATORY_8 { get; set; }
        public string AVARCREATE_8 { get; set; }
        [StringLength(50)]
        public string ACODE_9 { get; set; }
        [StringLength(50)]
        public string ATYPE_9 { get; set; }
        [StringLength(250)]
        public string ANAME_9 { get; set; }
        [StringLength(1)]
        public string AOPTIONS_9 { get; set; }
        public string AMANDATORY_9 { get; set; }
        public string AVARCREATE_9 { get; set; }
        [StringLength(50)]
        public string ACODE_10 { get; set; }
        [StringLength(50)]
        public string ATYPE_10 { get; set; }
        [StringLength(250)]
        public string ANAME_10 { get; set; }
        [StringLength(1)]
        public string AOPTIONS_10 { get; set; }
        public string AMANDATORY_10 { get; set; }
        public string AVARCREATE_10 { get; set; }
        [StringLength(50)]
        public string ACODE_11 { get; set; }
        [StringLength(50)]
        public string ATYPE_11 { get; set; }
        [StringLength(250)]
        public string ANAME_11 { get; set; }
        [StringLength(1)]
        public string AOPTIONS_11 { get; set; }
        public string AMANDATORY_11 { get; set; }
        public string AVARCREATE_11 { get; set; }
        [StringLength(50)]
        public string ACODE_12 { get; set; }
        [StringLength(50)]
        public string ATYPE_12 { get; set; }
        [StringLength(250)]
        public string ANAME_12 { get; set; }
        [StringLength(1)]
        public string AOPTIONS_12 { get; set; }
        public string AMANDATORY_12 { get; set; }
        public string AVARCREATE_12 { get; set; }
        [StringLength(50)]
        public string ACODE_13 { get; set; }
        [StringLength(50)]
        public string ATYPE_13 { get; set; }
        [StringLength(250)]
        public string ANAME_13 { get; set; }
        [StringLength(1)]
        public string AOPTIONS_13 { get; set; }
        public string AMANDATORY_13 { get; set; }
        public string AVARCREATE_13 { get; set; }
        [StringLength(50)]
        public string ACODE_14 { get; set; }
        [StringLength(50)]
        public string ATYPE_14 { get; set; }
        [StringLength(250)]
        public string ANAME_14 { get; set; }
        [StringLength(1)]
        public string AOPTIONS_14 { get; set; }
        public string AMANDATORY_14 { get; set; }
        public string AVARCREATE_14 { get; set; }
        [StringLength(50)]
        public string ACODE_15 { get; set; }
        [StringLength(50)]
        public string ATYPE_15 { get; set; }
        [StringLength(250)]
        public string ANAME_15 { get; set; }
        [StringLength(1)]
        public string AOPTIONS_15 { get; set; }
        public string AMANDATORY_15 { get; set; }
        public string AVARCREATE_15 { get; set; }
        [StringLength(50)]
        public string ACODE_16 { get; set; }
        [StringLength(50)]
        public string ATYPE_16 { get; set; }
        [StringLength(250)]
        public string ANAME_16 { get; set; }
        [StringLength(1)]
        public string AOPTIONS_16 { get; set; }
        public string AMANDATORY_16 { get; set; }
        public string AVARCREATE_16 { get; set; }
        [StringLength(50)]
        public string ACODE_17 { get; set; }
        [StringLength(50)]
        public string ATYPE_17 { get; set; }
        [StringLength(250)]
        public string ANAME_17 { get; set; }
        [StringLength(1)]
        public string AOPTIONS_17 { get; set; }
        public string AMANDATORY_17 { get; set; }
        public string AVARCREATE_17 { get; set; }
        [StringLength(50)]
        public string ACODE_18 { get; set; }
        [StringLength(50)]
        public string ATYPE_18 { get; set; }
        [StringLength(250)]
        public string ANAME_18 { get; set; }
        [StringLength(1)]
        public string AOPTIONS_18 { get; set; }
        public string AMANDATORY_18 { get; set; }
        public string AVARCREATE_18 { get; set; }
        [StringLength(50)]
        public string ACODE_19 { get; set; }
        [StringLength(50)]
        public string ATYPE_19 { get; set; }
        [StringLength(250)]
        public string ANAME_19 { get; set; }
        [StringLength(1)]
        public string AOPTIONS_19 { get; set; }
        public string AMANDATORY_19 { get; set; }
        public string AVARCREATE_19 { get; set; }
        [StringLength(50)]
        public string ACODE_20 { get; set; }
        [StringLength(50)]
        public string ATYPE_20 { get; set; }
        [StringLength(250)]
        public string ANAME_20 { get; set; }
        [StringLength(1)]
        public string AOPTIONS_20 { get; set; }
        public string AMANDATORY_20 { get; set; }
        public string AVARCREATE_20 { get; set; }
        [StringLength(50)]
        public string ACODE_21 { get; set; }
        [StringLength(50)]
        public string ATYPE_21 { get; set; }
        [StringLength(250)]
        public string ANAME_21 { get; set; }
        [StringLength(1)]
        public string AOPTIONS_21 { get; set; }
        public string AMANDATORY_21 { get; set; }
        public string AVARCREATE_21 { get; set; }
        [StringLength(50)]
        public string ACODE_22 { get; set; }
        [StringLength(50)]
        public string ATYPE_22 { get; set; }
        [StringLength(250)]
        public string ANAME_22 { get; set; }
        [StringLength(1)]
        public string AOPTIONS_22 { get; set; }
        public string AMANDATORY_22 { get; set; }
        public string AVARCREATE_22 { get; set; }
        [StringLength(50)]
        public string ACODE_23 { get; set; }
        [StringLength(50)]
        public string ATYPE_23 { get; set; }
        [StringLength(250)]
        public string ANAME_23 { get; set; }
        [StringLength(1)]
        public string AOPTIONS_23 { get; set; }
        public string AMANDATORY_23 { get; set; }
        public string AVARCREATE_23 { get; set; }
        [StringLength(50)]
        public string ACODE_24 { get; set; }
        [StringLength(50)]
        public string ATYPE_24 { get; set; }
        [StringLength(250)]
        public string ANAME_24 { get; set; }
        [StringLength(1)]
        public string AOPTIONS_24 { get; set; }
        public string AMANDATORY_24 { get; set; }
        public string AVARCREATE_24 { get; set; }
        [StringLength(50)]
        public string ACODE_25 { get; set; }
        [StringLength(50)]
        public string ATYPE_25 { get; set; }
        [StringLength(250)]
        public string ANAME_25 { get; set; }
        [StringLength(1)]
        public string AOPTIONS_25 { get; set; }
        public string AMANDATORY_25 { get; set; }
        public string AVARCREATE_25 { get; set; }
        [StringLength(50)]
        public string ACODE_26 { get; set; }
        [StringLength(50)]
        public string ATYPE_26 { get; set; }
        [StringLength(250)]
        public string ANAME_26 { get; set; }
        [StringLength(1)]
        public string AOPTIONS_26 { get; set; }
        public string AMANDATORY_26 { get; set; }
        public string AVARCREATE_26 { get; set; }
        [StringLength(50)]
        public string ACODE_27 { get; set; }
        [StringLength(50)]
        public string ATYPE_27 { get; set; }
        [StringLength(250)]
        public string ANAME_27 { get; set; }
        [StringLength(1)]
        public string AOPTIONS_27 { get; set; }
        public string AMANDATORY_27 { get; set; }
        public string AVARCREATE_27 { get; set; }
        [StringLength(50)]
        public string ACODE_28 { get; set; }
        [StringLength(50)]
        public string ATYPE_28 { get; set; }
        [StringLength(250)]
        public string ANAME_28 { get; set; }
        [StringLength(1)]
        public string AOPTIONS_28 { get; set; }
        public string AMANDATORY_28 { get; set; }
        public string AVARCREATE_28 { get; set; }
        [StringLength(50)]
        public string ACODE_29 { get; set; }
        [StringLength(50)]
        public string ATYPE_29 { get; set; }
        [StringLength(250)]
        public string ANAME_29 { get; set; }
        [StringLength(1)]
        public string AOPTIONS_29 { get; set; }
        public string AMANDATORY_29 { get; set; }
        public string AVARCREATE_29 { get; set; }
        [StringLength(50)]
        public string ACODE_30 { get; set; }
        [StringLength(50)]
        public string ATYPE_30 { get; set; }
        [StringLength(250)]
        public string ANAME_30 { get; set; }
        [StringLength(1)]
        public string AOPTIONS_30 { get; set; }
        public string AMANDATORY_30 { get; set; }
        public string AVARCREATE_30 { get; set; }

        [StringLength(50)]
        public string ACODE_31 { get; set; }
        [StringLength(50)]
        public string ATYPE_31 { get; set; }
        [StringLength(250)]
        public string ANAME_31 { get; set; }
        [StringLength(1)]
        public string AOPTIONS_31 { get; set; }
        public string AMANDATORY_31 { get; set; }
        public string AVARCREATE_31 { get; set; }
        [StringLength(50)]
        public string ACODE_32 { get; set; }
        [StringLength(50)]
        public string ATYPE_32 { get; set; }
        [StringLength(250)]
        public string ANAME_32 { get; set; }
        [StringLength(1)]
        public string AOPTIONS_32 { get; set; }
        public string AMANDATORY_32 { get; set; }
        public string AVARCREATE_32 { get; set; }
        [StringLength(50)]
        public string ACODE_33 { get; set; }
        [StringLength(50)]
        public string ATYPE_33 { get; set; }
        [StringLength(250)]
        public string ANAME_33 { get; set; }
        [StringLength(1)]
        public string AOPTIONS_33 { get; set; }
        public string AMANDATORY_33 { get; set; }
        public string AVARCREATE_33 { get; set; }
        [StringLength(50)]
        public string ACODE_34 { get; set; }
        [StringLength(50)]
        public string ATYPE_34 { get; set; }
        [StringLength(250)]
        public string ANAME_34 { get; set; }
        [StringLength(1)]
        public string AOPTIONS_34 { get; set; }
        public string AMANDATORY_34 { get; set; }
        public string AVARCREATE_34 { get; set; }
        [StringLength(50)]
        public string ACODE_35 { get; set; }
        [StringLength(50)]
        public string ATYPE_35 { get; set; }
        [StringLength(250)]
        public string ANAME_35 { get; set; }
        [StringLength(1)]
        public string AOPTIONS_35 { get; set; }
        public string AMANDATORY_35 { get; set; }
        public string AVARCREATE_35 { get; set; }
        public int? RecNum { get; set; }
    }
}