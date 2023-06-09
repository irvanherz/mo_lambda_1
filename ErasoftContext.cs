using System;
using System.Collections.Generic;
using System.Text;
using MO_Lambda.Models;

namespace MO_Lambda
{
    using System.Data.Entity;
    using System.Linq;

    class ErasoftContext : DbContext
    {
        public ErasoftContext()
            : base("name=ErasoftContext")
        {
        }

        public ErasoftContext(string dbSourceEra, string dbPathEra)
            : base($"Server={dbSourceEra};initial catalog={dbPathEra};" +
                   $"user id=sa;password=admin123^;multipleactiveresultsets=True;" +
                   $"application name=EntityFramework")
        {
        }

#if (AWS)
        public ErasoftContext(string dbPathEra)
             : base($"Server=172.31.20.192, 1433;initial catalog={dbPathEra};" +
                    $"user id=sa;password=admin123^;multipleactiveresultsets=True;" +
                    $"application name=EntityFramework")
        {
        }
#elif (Debug_AWS)
        public ErasoftContext(string dbPathEra)
             : base($"Server=54.151.175.62, 12354;initial catalog={dbPathEra};" +
                    $"user id=sa;password=admin123^;multipleactiveresultsets=True;" +
                    $"application name=EntityFramework")
        {
        }

#elif (DEV)
        public ErasoftContext(string dbPathEra)
             : base($"Server=172.31.20.73, 1433;initial catalog={dbPathEra};" +
                    $"user id=sa;password=admin123^;multipleactiveresultsets=True;" +
                    $"application name=EntityFramework")
        {
        }

#elif (DEBUG)
        public ErasoftContext(string dbPathEra)
             : base($"Server=54.151.175.62, 45650;initial catalog={dbPathEra};" +
                    $"user id=sa;password=admin123^;multipleactiveresultsets=True;" +
                    $"application name=EntityFramework")
        {
        }

#endif
        //add by ibrahim 19/08/2021
        public virtual DbSet<FAKTUR_API> FAKTUR_API { get; set; }
        //end add by ibrahim 19/08/2021
        public virtual DbSet<PARTNER_API> PARTNER_API { get; set; }
        public virtual DbSet<PARTNER_API_LOG_ERROR> PARTNER_API_LOG_ERROR { get; set; }

        public virtual DbSet<Promosi> PROMOSI { get; set; }
        public virtual DbSet<DetailPromosi> DETAILPROMOSI { get; set; }
        public virtual DbSet<APF01> APF01 { get; set; }
        public virtual DbSet<APF01A> APF01A { get; set; }
        public virtual DbSet<APF02> APF02 { get; set; }
        public virtual DbSet<APF02A> APF02A { get; set; }
        public virtual DbSet<APF02B> APF02B { get; set; }
        public virtual DbSet<APF03> APF03 { get; set; }
        public virtual DbSet<APF03A> APF03A { get; set; }
        public virtual DbSet<APF04> APF04 { get; set; }
        public virtual DbSet<APF05> APF05 { get; set; }
        public virtual DbSet<APF05A> APF05A { get; set; }
        public virtual DbSet<APF11> APF11 { get; set; }
        public virtual DbSet<APFSY> APFSYS { get; set; }
        public virtual DbSet<APLINK> APLINKs { get; set; }
        public virtual DbSet<APT01A> APT01A { get; set; }
        public virtual DbSet<APT01B> APT01B { get; set; }
        public virtual DbSet<APT01C> APT01C { get; set; }
        public virtual DbSet<APT01D> APT01D { get; set; }
        public virtual DbSet<APT02> APT02 { get; set; }
        public virtual DbSet<APT02B> APT02B { get; set; }
        public virtual DbSet<APT02C> APT02C { get; set; }
        public virtual DbSet<APT03A> APT03A { get; set; }
        public virtual DbSet<APT03B> APT03B { get; set; }
        public virtual DbSet<APT03C> APT03C { get; set; }
        public virtual DbSet<APT04A> APT04A { get; set; }
        public virtual DbSet<APT04B> APT04B { get; set; }
        public virtual DbSet<APURUT> APURUTs { get; set; }
        public virtual DbSet<ARF01> ARF01 { get; set; }
        public virtual DbSet<ARF01A> ARF01A { get; set; }
        public virtual DbSet<ARF01B> ARF01B { get; set; }
        public virtual DbSet<ARF01C> ARF01C { get; set; }
        public virtual DbSet<ARF02> ARF02 { get; set; }
        public virtual DbSet<ARF02A> ARF02A { get; set; }
        public virtual DbSet<ARF02B> ARF02B { get; set; }
        public virtual DbSet<ARF03> ARF03 { get; set; }
        public virtual DbSet<ARF03A> ARF03A { get; set; }
        public virtual DbSet<ARF04> ARF04 { get; set; }
        public virtual DbSet<ARF05> ARF05 { get; set; }
        public virtual DbSet<ARF05A> ARF05A { get; set; }
        public virtual DbSet<ARF06A> ARF06A { get; set; }
        public virtual DbSet<ARF06B> ARF06B { get; set; }
        public virtual DbSet<ARF07> ARF07 { get; set; }
        public virtual DbSet<ARF08> ARF08 { get; set; }
        public virtual DbSet<ARF08B> ARF08B { get; set; }
        public virtual DbSet<ARF10> ARF10 { get; set; }
        public virtual DbSet<ARF11> ARF11 { get; set; }
        public virtual DbSet<ARF12> ARF12 { get; set; }
        public virtual DbSet<ARF13> ARF13 { get; set; }
        public virtual DbSet<ARF14> ARF14 { get; set; }
        public virtual DbSet<ARF15> ARF15 { get; set; }
        public virtual DbSet<ARF16> ARF16 { get; set; }
        public virtual DbSet<ARF17> ARF17 { get; set; }
        public virtual DbSet<ARF19> ARF19 { get; set; }
        public virtual DbSet<ARF20> ARF20 { get; set; }
        public virtual DbSet<ARF22> ARF22 { get; set; }
        public virtual DbSet<ARFSY> ARFSYS { get; set; }
        public virtual DbSet<ARLINK> ARLINKs { get; set; }
        public virtual DbSet<ART01A> ART01A { get; set; }
        public virtual DbSet<ART01B> ART01B { get; set; }
        public virtual DbSet<ART01C> ART01C { get; set; }
        public virtual DbSet<ART01D> ART01D { get; set; }
        public virtual DbSet<ART02> ART02 { get; set; }
        public virtual DbSet<ART02B> ART02B { get; set; }
        public virtual DbSet<ART02C> ART02C { get; set; }
        public virtual DbSet<ART03A> ART03A { get; set; }
        public virtual DbSet<ART03B> ART03B { get; set; }
        public virtual DbSet<ART03C> ART03C { get; set; }
        public virtual DbSet<ART04A> ART04A { get; set; }
        public virtual DbSet<ART04B> ART04B { get; set; }
        public virtual DbSet<ART04C> ART04C { get; set; }
        public virtual DbSet<ARURUT> ARURUTs { get; set; }
        public virtual DbSet<dtproperty> dtproperties { get; set; }
        public virtual DbSet<GLBatchTable> GLBatchTables { get; set; }
        public virtual DbSet<GLF002> GLF002 { get; set; }
        public virtual DbSet<GLFAUTO1> GLFAUTO1 { get; set; }
        public virtual DbSet<GLFAUTO2> GLFAUTO2 { get; set; }
        public virtual DbSet<GLFBATCH> GLFBATCHes { get; set; }
        public virtual DbSet<GLFBIAYA> GLFBIAYAs { get; set; }
        public virtual DbSet<GLFBUD> GLFBUDs { get; set; }
        public virtual DbSet<GLFBUD_TEMP> GLFBUD_TEMP { get; set; }
        public virtual DbSet<GLFBUK> GLFBUKs { get; set; }
        public virtual DbSet<GLFCAB> GLFCABs { get; set; }
        public virtual DbSet<GLFCAB_A> GLFCAB_A { get; set; }
        public virtual DbSet<GLFCL> GLFCLS { get; set; }
        public virtual DbSet<GLFDEPT> GLFDEPTs { get; set; }
        public virtual DbSet<GLFDNE> GLFDNEs { get; set; }
        public virtual DbSet<GLFDRL> GLFDRLs { get; set; }
        public virtual DbSet<GLFELI> GLFELIs { get; set; }
        public virtual DbSet<GLFFIXED> GLFFIXEDs { get; set; }
        public virtual DbSet<GLFGRAP1> GLFGRAP1 { get; set; }
        public virtual DbSet<GLFGRAP2> GLFGRAP2 { get; set; }
        public virtual DbSet<GLFJTTAP> GLFJTTAPs { get; set; }
        public virtual DbSet<GLFJUR> GLFJURs { get; set; }
        public virtual DbSet<GLFKEL> GLFKELs { get; set; }
        public virtual DbSet<GLFLAMP1> GLFLAMP1 { get; set; }
        public virtual DbSet<GLFLAMP2> GLFLAMP2 { get; set; }
        public virtual DbSet<GLFLAMP3> GLFLAMP3 { get; set; }
        public virtual DbSet<GLFLAMP4> GLFLAMP4 { get; set; }
        public virtual DbSet<GLFLARI> GLFLARIS { get; set; }
        public virtual DbSet<GLFLEVEL> GLFLEVELs { get; set; }
        public virtual DbSet<GLFMDL1> GLFMDL1 { get; set; }
        public virtual DbSet<GLFMDL2> GLFMDL2 { get; set; }
        public virtual DbSet<GLFMDL3> GLFMDL3 { get; set; }
        public virtual DbSet<GLFMTL> GLFMTLs { get; set; }
        public virtual DbSet<GLFMUT> GLFMUTs { get; set; }
        public virtual DbSet<GLFMUT2> GLFMUT2 { get; set; }
        public virtual DbSet<GLFMUT3> GLFMUT3 { get; set; }
        public virtual DbSet<GLFNER> GLFNERs { get; set; }
        public virtual DbSet<GLFNER1> GLFNER1 { get; set; }
        public virtual DbSet<GLFNER2> GLFNER2 { get; set; }
        public virtual DbSet<GLFNER3> GLFNER3 { get; set; }
        public virtual DbSet<GLFNER4> GLFNER4 { get; set; }
        public virtual DbSet<GLFREK> GLFREKs { get; set; }
        public virtual DbSet<GLFREK_A> GLFREK_A { get; set; }
        public virtual DbSet<GLFREK2> GLFREK2 { get; set; }
        public virtual DbSet<GLFREKTEMP> GLFREKTEMPs { get; set; }
        public virtual DbSet<GLFREV> GLFREVs { get; set; }
        public virtual DbSet<GLFRLA1> GLFRLA1 { get; set; }
        public virtual DbSet<GLFRLA2> GLFRLA2 { get; set; }
        public virtual DbSet<GLFRLA3> GLFRLA3 { get; set; }
        public virtual DbSet<GLFRLA4> GLFRLA4 { get; set; }
        public virtual DbSet<GLFSTTAP> GLFSTTAPs { get; set; }
        public virtual DbSet<GLFSY> GLFSYS { get; set; }
        public virtual DbSet<GLFSYS_old> GLFSYS_old { get; set; }
        public virtual DbSet<GLFTAWAL> GLFTAWALs { get; set; }
        public virtual DbSet<GLFTEMP> GLFTEMPs { get; set; }
        public virtual DbSet<GLFTEMP1> GLFTEMP1 { get; set; }
        public virtual DbSet<GLFTEMP2> GLFTEMP2 { get; set; }
        public virtual DbSet<GLFTEMP3> GLFTEMP3 { get; set; }
        public virtual DbSet<GLFTLINK1> GLFTLINK1 { get; set; }
        public virtual DbSet<GLFTLINK2> GLFTLINK2 { get; set; }
        public virtual DbSet<GLFTRAN1> GLFTRAN1 { get; set; }
        public virtual DbSet<GLFTRAN1TEMP> GLFTRAN1TEMP { get; set; }
        public virtual DbSet<GLFTRAN2> GLFTRAN2 { get; set; }
        public virtual DbSet<GLFTRAN2TEMP> GLFTRAN2TEMP { get; set; }
        public virtual DbSet<GLFVAL> GLFVALs { get; set; }
        public virtual DbSet<GLFVAL2> GLFVAL2 { get; set; }
        public virtual DbSet<GLRF01> GLRF01 { get; set; }
        public virtual DbSet<GLRF02> GLRF02 { get; set; }
        public virtual DbSet<INQUERYPP> INQUERYPPs { get; set; }
        public virtual DbSet<INQUERYP> INQUERYPS { get; set; }
        public virtual DbSet<PBF01> PBF01 { get; set; }
        public virtual DbSet<PBF02> PBF02 { get; set; }
        public virtual DbSet<PBF03> PBF03 { get; set; }
        public virtual DbSet<PBF04> PBF04 { get; set; }
        public virtual DbSet<PBF05> PBF05 { get; set; }
        public virtual DbSet<PBFLOCK> PBFLOCKs { get; set; }
        public virtual DbSet<PBFSY> PBFSYS { get; set; }
        public virtual DbSet<PBT01A> PBT01A { get; set; }
        public virtual DbSet<PBT01B> PBT01B { get; set; }
        public virtual DbSet<PBT01B1> PBT01B1 { get; set; }
        public virtual DbSet<PBT01C> PBT01C { get; set; }
        public virtual DbSet<PBT01D> PBT01D { get; set; }
        public virtual DbSet<PBT01E> PBT01E { get; set; }
        public virtual DbSet<PBT01F> PBT01F { get; set; }
        public virtual DbSet<PBT01G> PBT01G { get; set; }
        public virtual DbSet<PBT01H> PBT01H { get; set; }
        public virtual DbSet<PBT01I> PBT01I { get; set; }
        public virtual DbSet<PBT02> PBT02 { get; set; }
        public virtual DbSet<PBT03> PBT03 { get; set; }
        public virtual DbSet<POF01> POF01 { get; set; }
        public virtual DbSet<POF02> POF02 { get; set; }
        public virtual DbSet<POF02A> POF02A { get; set; }
        public virtual DbSet<POF03> POF03 { get; set; }
        public virtual DbSet<POF03A> POF03A { get; set; }
        public virtual DbSet<POF04> POF04 { get; set; }
        public virtual DbSet<POF05> POF05 { get; set; }
        public virtual DbSet<POF06A> POF06A { get; set; }
        public virtual DbSet<POF06B> POF06B { get; set; }
        public virtual DbSet<POF07> POF07 { get; set; }
        public virtual DbSet<POF08> POF08 { get; set; }
        public virtual DbSet<POF09> POF09 { get; set; }
        public virtual DbSet<POF10> POF10 { get; set; }
        public virtual DbSet<POF11> POF11 { get; set; }
        public virtual DbSet<POF11B> POF11B { get; set; }
        public virtual DbSet<POF12> POF12 { get; set; }
        public virtual DbSet<POF12B> POF12B { get; set; }
        public virtual DbSet<POF13> POF13 { get; set; }
        public virtual DbSet<POF14A> POF14A { get; set; }
        public virtual DbSet<POF14B> POF14B { get; set; }
        public virtual DbSet<POF15> POF15 { get; set; }
        public virtual DbSet<POF16A> POF16A { get; set; }
        public virtual DbSet<POF16B> POF16B { get; set; }
        public virtual DbSet<POF17A> POF17A { get; set; }
        public virtual DbSet<POF17B> POF17B { get; set; }
        public virtual DbSet<POF18> POF18 { get; set; }
        public virtual DbSet<POF19> POF19 { get; set; }
        public virtual DbSet<POF20> POF20 { get; set; }
        public virtual DbSet<POF21A> POF21A { get; set; }
        public virtual DbSet<POF21B> POF21B { get; set; }
        public virtual DbSet<POF22A> POF22A { get; set; }
        public virtual DbSet<POF22B> POF22B { get; set; }
        public virtual DbSet<POF24> POF24 { get; set; }
        public virtual DbSet<POF25> POF25 { get; set; }
        public virtual DbSet<POFLOCK01> POFLOCK01 { get; set; }
        public virtual DbSet<POFLOCK02> POFLOCK02 { get; set; }
        public virtual DbSet<POFLOCK03> POFLOCK03 { get; set; }
        public virtual DbSet<POFSY> POFSYS { get; set; }
        public virtual DbSet<POT01A> POT01A { get; set; }
        public virtual DbSet<POT01B> POT01B { get; set; }
        public virtual DbSet<POT01B1> POT01B1 { get; set; }
        public virtual DbSet<POT01C> POT01C { get; set; }
        public virtual DbSet<POT01D> POT01D { get; set; }
        public virtual DbSet<POT01E> POT01E { get; set; }
        public virtual DbSet<POT01F> POT01F { get; set; }
        public virtual DbSet<POT01G> POT01G { get; set; }
        public virtual DbSet<POT01H> POT01H { get; set; }
        public virtual DbSet<POT02A> POT02A { get; set; }
        public virtual DbSet<POT02B> POT02B { get; set; }
        public virtual DbSet<POT02C> POT02C { get; set; }
        public virtual DbSet<POT02E> POT02E { get; set; }
        public virtual DbSet<POT02F> POT02F { get; set; }
        public virtual DbSet<POT03> POT03 { get; set; }
        public virtual DbSet<POT03A> POT03A { get; set; }
        public virtual DbSet<POT03B> POT03B { get; set; }
        public virtual DbSet<POT03C> POT03C { get; set; }
        public virtual DbSet<POT03D> POT03D { get; set; }
        public virtual DbSet<POT04A> POT04A { get; set; }
        public virtual DbSet<POT04B> POT04B { get; set; }
        public virtual DbSet<POT04C> POT04C { get; set; }
        public virtual DbSet<POT04D> POT04D { get; set; }
        public virtual DbSet<POT05A> POT05A { get; set; }
        public virtual DbSet<POT05B> POT05B { get; set; }
        public virtual DbSet<POT05C> POT05C { get; set; }
        public virtual DbSet<POT05D> POT05D { get; set; }
        public virtual DbSet<SDF08> SDF08 { get; set; }
        public virtual DbSet<SIF01> SIF01 { get; set; }
        public virtual DbSet<SIF02> SIF02 { get; set; }
        public virtual DbSet<SIF03> SIF03 { get; set; }
        public virtual DbSet<SIF04> SIF04 { get; set; }
        public virtual DbSet<SIF05> SIF05 { get; set; }
        public virtual DbSet<SIF06> SIF06 { get; set; }
        public virtual DbSet<SIF07> SIF07 { get; set; }
        public virtual DbSet<SIF08A> SIF08A { get; set; }
        public virtual DbSet<SIF08B> SIF08B { get; set; }
        public virtual DbSet<SIF09> SIF09 { get; set; }
        public virtual DbSet<SIF10> SIF10 { get; set; }
        public virtual DbSet<SIF11> SIF11 { get; set; }
        public virtual DbSet<SIF12> SIF12 { get; set; }
        public virtual DbSet<SIF13A> SIF13A { get; set; }
        public virtual DbSet<SIF13B> SIF13B { get; set; }
        public virtual DbSet<SIF14> SIF14 { get; set; }
        public virtual DbSet<SIF15A> SIF15A { get; set; }
        public virtual DbSet<SIF15B> SIF15B { get; set; }
        public virtual DbSet<SIF16A> SIF16A { get; set; }
        public virtual DbSet<SIF16B> SIF16B { get; set; }
        public virtual DbSet<SIF16C> SIF16C { get; set; }
        public virtual DbSet<SIF17A> SIF17A { get; set; }
        public virtual DbSet<SIF17B> SIF17B { get; set; }
        public virtual DbSet<SIF18A> SIF18A { get; set; }
        public virtual DbSet<SIF18B> SIF18B { get; set; }
        public virtual DbSet<SIF22> SIF22 { get; set; }
        public virtual DbSet<SIF23> SIF23 { get; set; }
        public virtual DbSet<SIF24> SIF24 { get; set; }
        public virtual DbSet<SIFLOCK> SIFLOCKs { get; set; }
        public virtual DbSet<SIFSY> SIFSYS { get; set; }
        public virtual DbSet<SIFSYS_TAMBAHAN> SIFSYS_TAMBAHAN { get; set; }
        public virtual DbSet<SIFSYS_DS> SIFSYS_DS { get; set; }
        public virtual DbSet<SIT01A> SIT01A { get; set; }
        public virtual DbSet<SIT01B> SIT01B { get; set; }
        public virtual DbSet<SIT01B1> SIT01B1 { get; set; }
        public virtual DbSet<SIT01C> SIT01C { get; set; }
        public virtual DbSet<SIT01D> SIT01D { get; set; }
        public virtual DbSet<SIT01E> SIT01E { get; set; }
        public virtual DbSet<SIT01F> SIT01F { get; set; }
        public virtual DbSet<SIT01G> SIT01G { get; set; }
        public virtual DbSet<SIT02A> SIT02A { get; set; }
        public virtual DbSet<SIT02B> SIT02B { get; set; }
        public virtual DbSet<SIT02C> SIT02C { get; set; }
        public virtual DbSet<SIT03A> SIT03A { get; set; }
        public virtual DbSet<SIT03B> SIT03B { get; set; }
        public virtual DbSet<SIT03C> SIT03C { get; set; }
        public virtual DbSet<SOF01> SOF01 { get; set; }
        public virtual DbSet<SOF02> SOF02 { get; set; }
        public virtual DbSet<SOF03> SOF03 { get; set; }
        public virtual DbSet<SOFLOCK> SOFLOCKs { get; set; }
        public virtual DbSet<SOFSY> SOFSYS { get; set; }
        public virtual DbSet<SOT01A> SOT01A { get; set; }
        public virtual DbSet<SOT01B> SOT01B { get; set; }
        public virtual DbSet<SOT01B2> SOT01B2 { get; set; }
        public virtual DbSet<SOT01C> SOT01C { get; set; }
        public virtual DbSet<SOT01D> SOT01D { get; set; }
        public virtual DbSet<SOT01E> SOT01E { get; set; }
        public virtual DbSet<SOT01F> SOT01F { get; set; }
        public virtual DbSet<SOT02A> SOT02A { get; set; }
        public virtual DbSet<SOT02B> SOT02B { get; set; }
        public virtual DbSet<SOT02C> SOT02C { get; set; }
        public virtual DbSet<SOT02D> SOT02D { get; set; }
        public virtual DbSet<STF02> STF02 { get; set; }
        public virtual DbSet<STF02A1> STF02A1 { get; set; }
        public virtual DbSet<STF02B> STF02B { get; set; }
        public virtual DbSet<STF02C> STF02C { get; set; }
        public virtual DbSet<STF02D> STF02D { get; set; }
        public virtual DbSet<STF02E> STF02E { get; set; }
        public virtual DbSet<STF02F> STF02F { get; set; }
        public virtual DbSet<STF02G> STF02G { get; set; }
        public virtual DbSet<STF02H> STF02H { get; set; }
        public virtual DbSet<STF03> STF03 { get; set; }
        public virtual DbSet<STF04> STF04 { get; set; }
        public virtual DbSet<STF05> STF05 { get; set; }
        public virtual DbSet<STF05A> STF05A { get; set; }
        public virtual DbSet<STF06> STF06 { get; set; }
        public virtual DbSet<STF07> STF07 { get; set; }
        public virtual DbSet<STF08> STF08 { get; set; }
        public virtual DbSet<STF08A> STF08A { get; set; }
        public virtual DbSet<STF08B> STF08B { get; set; }
        public virtual DbSet<STF09> STF09 { get; set; }
        public virtual DbSet<STF09A> STF09A { get; set; }
        public virtual DbSet<STF09B> STF09B { get; set; }
        public virtual DbSet<STF09C> STF09C { get; set; }
        public virtual DbSet<STF10> STF10 { get; set; }
        public virtual DbSet<STF10B> STF10B { get; set; }
        public virtual DbSet<STF11> STF11 { get; set; }
        public virtual DbSet<STF11B> STF11B { get; set; }
        public virtual DbSet<STF11C> STF11C { get; set; }
        public virtual DbSet<STF11D> STF11D { get; set; }
        public virtual DbSet<STF12> STF12 { get; set; }
        public virtual DbSet<STF13> STF13 { get; set; }
        public virtual DbSet<STF14> STF14 { get; set; }
        public virtual DbSet<STF16> STF16 { get; set; }
        public virtual DbSet<STF18> STF18 { get; set; }
        public virtual DbSet<STF19> STF19 { get; set; }
        public virtual DbSet<STFCAT> STFCATs { get; set; }
        public virtual DbSet<STFLINE> STFLINEs { get; set; }
        public virtual DbSet<STFLOCK01> STFLOCK01 { get; set; }
        public virtual DbSet<STFLOCK02> STFLOCK02 { get; set; }
        public virtual DbSet<STFSY> STFSYS { get; set; }
        public virtual DbSet<STLINK> STLINKs { get; set; }
        public virtual DbSet<STLINK2A> STLINK2A { get; set; }
        public virtual DbSet<STLINK2B> STLINK2B { get; set; }
        public virtual DbSet<STT01A> STT01A { get; set; }
        public virtual DbSet<STT01B> STT01B { get; set; }
        public virtual DbSet<STT01B1> STT01B1 { get; set; }
        public virtual DbSet<STT01C> STT01C { get; set; }
        public virtual DbSet<STT01C1> STT01C1 { get; set; }
        public virtual DbSet<STT01D> STT01D { get; set; }
        public virtual DbSet<STT02> STT02 { get; set; }
        public virtual DbSet<STT02A> STT02A { get; set; }
        public virtual DbSet<STT02B> STT02B { get; set; }
        public virtual DbSet<STT03A> STT03A { get; set; }
        public virtual DbSet<STT03B> STT03B { get; set; }
        public virtual DbSet<STT04A> STT04A { get; set; }
        public virtual DbSet<STT04B> STT04B { get; set; }
        public virtual DbSet<STT04B1> STT04B1 { get; set; }
        public virtual DbSet<STT04C> STT04C { get; set; }
        public virtual DbSet<STT04D> STT04D { get; set; }
        public virtual DbSet<STT05A> STT05A { get; set; }
        public virtual DbSet<STT05B> STT05B { get; set; }
        public virtual DbSet<STT06> STT06 { get; set; }
        public virtual DbSet<STT07A> STT07A { get; set; }
        public virtual DbSet<STT07B> STT07B { get; set; }
        public virtual DbSet<STT07C> STT07C { get; set; }
        public virtual DbSet<STT07D> STT07D { get; set; }
        public virtual DbSet<STURUT> STURUTs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TRF03> TRF03 { get; set; }
        public virtual DbSet<PBT03A> PBT03A { get; set; }
        public virtual DbSet<PBT03B> PBT03B { get; set; }
        public virtual DbSet<POSISISTOCK> POSISISTOCKs { get; set; }
        public virtual DbSet<SIF19> SIF19 { get; set; }
        public virtual DbSet<SIF20A> SIF20A { get; set; }
        public virtual DbSet<SIF20B> SIF20B { get; set; }
        public virtual DbSet<SIF21> SIF21 { get; set; }
        public virtual DbSet<SIFSYS_NEW> SIFSYS_NEW { get; set; }
        public virtual DbSet<SKFSY> SKFSYS { get; set; }
        public virtual DbSet<STFSYS_M> STFSYS_M { get; set; }
        public virtual DbSet<TEMP_PBT01A> TEMP_PBT01A { get; set; }
        public virtual DbSet<TEMP_PBT01B> TEMP_PBT01B { get; set; }
        public virtual DbSet<TEMP_PBT01C> TEMP_PBT01C { get; set; }
        public virtual DbSet<TEMP_PBT01D> TEMP_PBT01D { get; set; }
        public virtual DbSet<TEMP_PBT01E> TEMP_PBT01E { get; set; }
        public virtual DbSet<TEMP_PBT01F> TEMP_PBT01F { get; set; }
        public virtual DbSet<TEMP_POST> TEMP_POST { get; set; }
        public virtual DbSet<TEMP_SIT01A> TEMP_SIT01A { get; set; }
        public virtual DbSet<TEMP_SIT01B> TEMP_SIT01B { get; set; }
        public virtual DbSet<TEMP_SIT01C> TEMP_SIT01C { get; set; }
        public virtual DbSet<TEMP_SIT01D> TEMP_SIT01D { get; set; }
        public virtual DbSet<TEMP_SIT01E> TEMP_SIT01E { get; set; }
        public virtual DbSet<TEMP_SIT01F> TEMP_SIT01F { get; set; }
        public virtual DbSet<TEMP_SIT01G> TEMP_SIT01G { get; set; }
        public virtual DbSet<TEMP_STF08> TEMP_STF08 { get; set; }
        public virtual DbSet<TEMP_STF09> TEMP_STF09 { get; set; }
        public virtual DbSet<TEMP_STT01A> TEMP_STT01A { get; set; }
        public virtual DbSet<TEMP_STT01B> TEMP_STT01B { get; set; }
        public virtual DbSet<TEMP_STT01C> TEMP_STT01C { get; set; }
        public virtual DbSet<tmp_STF08> tmp_STF08 { get; set; }
        public virtual DbSet<tmp_STF08A> tmp_STF08A { get; set; }
        public virtual DbSet<tmp_STF09> tmp_STF09 { get; set; }
        public virtual DbSet<tmp_STF09A> tmp_STF09A { get; set; }
        public virtual DbSet<DeliveryTemplateElevenia> DeliveryTemplateElevenia { get; set; }
        public virtual DbSet<PICKUP_POINT_BLIBLI> PICKUP_POINT_BLIBLI { get; set; }
        public virtual DbSet<DELIVERY_PROVIDER_LAZADA> DELIVERY_PROVIDER_LAZADA { get; set; }
        public virtual DbSet<DELIVERY_PROVIDER_TIKTOK> DELIVERY_PROVIDER_TIKTOK { get; set; }
        public virtual DbSet<API_LOG_MARKETPLACE> API_LOG_MARKETPLACE { get; set; }
        public virtual DbSet<LOG_IMPORT_FAKTUR> LOG_IMPORT_FAKTUR { get; set; }
        public virtual DbSet<TEMP_BRG_MP> TEMP_BRG_MP { get; set; }
        public virtual DbSet<TEMP_SHOPEE_ORDERS> TEMP_SHOPEE_ORDERS { get; set; }
        public virtual DbSet<TEMP_SHOPEE_ORDERS_ITEM> TEMP_SHOPEE_ORDERS_ITEM { get; set; }
        public virtual DbSet<TEMP_TIKTOK_ORDERS> TEMP_TIKTOK_ORDERS { get; set; }
        public virtual DbSet<TEMP_TIKTOK_ORDERS_ITEM> TEMP_TIKTOK_ORDERS_ITEM { get; set; }
        //add by fauzi for 82cart
        public virtual DbSet<TEMP_82CART_ORDERS> TEMP_82CART_ORDERS { get; set; }
        public virtual DbSet<TEMP_82CART_ORDERS_ITEM> TEMP_82CART_ORDERS_ITEM { get; set; }
        public DbSet<CATEGORY_82CART> Category82Cart { get; set; }
        //end by fauzi for 82cart
        //add by fauzi for shopify
        public virtual DbSet<TEMP_SHOPIFY_ORDERS> TEMP_SHOPIFY_ORDERS { get; set; }
        public virtual DbSet<TEMP_SHOPIFY_ORDERS_ITEM> TEMP_SHOPIFY_ORDERS_ITEM { get; set; }
        //end by fauzi
        //add by fauzi for upload saldo awal upgrade
        public virtual DbSet<TEMP_SALDOAWAL> TEMP_SALDOAWAL { get; set; }
        //end by fauzi for upload saldo awal upgrade

        public virtual DbSet<TEMP_TOKPED_ORDERS> TEMP_TOKPED_ORDERS { get; set; }
        //public virtual DbSet<API_LOG_MARKETPLACE_PER_ITEM> API_LOG_MARKETPLACE_PER_ITEM { get; set; }
        //public virtual DbSet<TEMP_BRG_MP_EXCEL> TEMP_BRG_MP_EXCEL { get; set; }
        public virtual DbSet<STF20> STF20 { get; set; }
        public virtual DbSet<STF20B> STF20B { get; set; }
        public virtual DbSet<STF02I> STF02I { get; set; }
        public virtual DbSet<CATEGORY_JDID> CATEGORY_JDID { get; set; }

        //add by nurul 20/8/2019
        public virtual DbSet<SIT04A> SIT04A { get; set; }
        public virtual DbSet<SIT04B> SIT04B { get; set; }
        //end add by nurul 20/8/2019

        //add by Tri 20/8/2019
        public virtual DbSet<SOT03A> SOT03A { get; set; }
        public virtual DbSet<SOT03B> SOT03B { get; set; }
        public virtual DbSet<SOT03C> SOT03C { get; set; }
        //end add by Tri 20/8/2019

        //add by nurul 9/4/2020
        public virtual DbSet<TABLE_LOG_DETAIL> TABLE_LOG_DETAIL { get; set; }
        public virtual DbSet<TEMP_UPLOAD_EXCEL_BAYAR> TEMP_UPLOAD_EXCEL_BAYAR { get; set; }
        //end add by nurul 9/4/2020

        //add by fauzi fitur Upload Excel Invoice Pembelian 04/03/2021
        public virtual DbSet<TEMP_UPLOAD_EXCEL_INVOICE_PEMBELIAN> TEMP_UPLOAD_EXCEL_INVOICE_PEMBELIAN { get; set; }
        //end add by fauzi 04/03/2021

        //add by Tri harga jual massal
        public virtual DbSet<LOG_HARGAJUAL_A> LOG_HARGAJUAL_A { get; set; }
        public virtual DbSet<LOG_HARGAJUAL_B> LOG_HARGAJUAL_B { get; set; }
        //end add by Tri harga jual massal

        //add by otniel 10/9/2020        
        public virtual DbSet<LINKFTP> LINKFTP { get; set; }
        //end by otniel 10/9/2020

        //add by nurul 19/8/2020
        public virtual DbSet<STF03C> STF03C { get; set; }
        //end add by nurul 19/8/2020

        //add by nurul 22/10/2020
        public virtual DbSet<SOT01G> SOT01G { get; set; }
        public virtual DbSet<SIT01H> SIT01H { get; set; }
        //end add by nurul 22/10/2020

        //add by nurul 19/3/2021
        public virtual DbSet<SOT01H> SOT01H { get; set; }
        //end add by nurul 19/3/2021

        //add by nurul 19/3/2021
        public virtual DbSet<TEMP_SHOPEE_BRAND> TEMP_SHOPEE_BRAND { get; set; }
        //end add by nurul 19/3/2021
        //public virtual DbSet<TABEL_TIKTOK_BRAND> TABEL_TIKTOK_BRAND { get; set; }
        public DbSet<CATEGORY_TIKTOK> CATEGORY_TIKTOK { get; set; }

        //add by nurul 25/8/2021
        public virtual DbSet<PEMBELI_FAKTUR_SHOPEE> PEMBELI_FAKTUR_SHOPEE { get; set; }
        //end add by nurul 25/8/2021

        //add by nurul 20/9/2021
        public virtual DbSet<TOKPED_LISTMESSAGE> TOKPED_LISTMESSAGE { get; set; }
        public virtual DbSet<TOKPED_LISTCHAT> TOKPED_LISTCHAT { get; set; }
        public virtual DbSet<SHOPEE_LISTCONVERSATION> SHOPEE_LISTCONVERSATION { get; set; }
        public virtual DbSet<SHOPEE_MESSAGE> SHOPEE_MESSAGE { get; set; }
        //end add by nurul 20/9/2021

        //add by nurul 8/2/2022
        public virtual DbSet<LAZADA_SESSIONLIST> LAZADA_SESSIONLIST { get; set; }
        public virtual DbSet<LAZADA_MESSAGES> LAZADA_MESSAGES { get; set; }
        //end add by nurul 8/2/2022

        //add by nurul 2/1/2022
        public virtual DbSet<MAPPING_GUDANG> MAPPING_GUDANG { get; set; }
        //add by nurul 2/1/2022

    }
}
