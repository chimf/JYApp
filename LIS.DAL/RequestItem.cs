// Decompiled with JetBrains decompiler
// Type: LIS.Model.Entity.RequestItem
// Assembly: LIS.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E5DBE903-696A-4217-96C9-751E663D78F1
// Assembly location: D:\智方科技\医院程序集合\江西.南昌省妇幼医院\LisInterface2012(20190610)\bin\LIS.Model.dll

using System;

namespace LIS.Model.Entity
{
  [Serializable]
  public class RequestItem
  {
    private int? _isredo = new int?(0);
    private DateTime _receivedate;
    private int _sectionno;
    private int _testtypeno;
    private string _sampleno;
    private int _paritemno;
    private int _itemno;
    private Decimal? _originalvalue;
    private Decimal? _reportvalue;
    private string _originaldesc;
    private string _reportdesc;
    private int? _statusno;
    private string _refrange;
    private int? _equipno;
    private int? _modified;
    private DateTime? _itemdate;
    private DateTime? _itemtime;
    private int? _ismatch;
    private string _resultstatus;
    private string _hisvalue;
    private string _hiscomp;
    private int? _isreceive;
    private string _countnodesitemsource;
    private string _unit;
    private int? _plateno;
    private int? _positionno;
    private string _equipcommmemo;
    private int? _equipcommsend;
    private string _evaluestate;
    private string _emodule;
    private string _eposition;
    private string _esend;
    private string _zdy1;
    private string _zdy2;
    private string _zdy3;
    private int? _isdel;
    private string _serialnoparent;
    private string _mergeno;
    private string _oldparitemno;

    public DateTime ReceiveDate
    {
      get
      {
        return this._receivedate;
      }
      set
      {
        this._receivedate = value;
      }
    }

    public int SectionNo
    {
      get
      {
        return this._sectionno;
      }
      set
      {
        this._sectionno = value;
      }
    }

    public int TestTypeNo
    {
      get
      {
        return this._testtypeno;
      }
      set
      {
        this._testtypeno = value;
      }
    }

    public string SampleNo
    {
      get
      {
        return this._sampleno;
      }
      set
      {
        this._sampleno = value;
      }
    }

    public int ParItemNo
    {
      get
      {
        return this._paritemno;
      }
      set
      {
        this._paritemno = value;
      }
    }

    public int ItemNo
    {
      get
      {
        return this._itemno;
      }
      set
      {
        this._itemno = value;
      }
    }

    public string serialnoparent
    {
      get
      {
        return this._serialnoparent;
      }
      set
      {
        this._serialnoparent = value;
      }
    }

    public string Mergeno
    {
      get
      {
        return this._mergeno;
      }
      set
      {
        this._mergeno = value;
      }
    }

    public string OldParItemno
    {
      get
      {
        return this._oldparitemno;
      }
      set
      {
        this._oldparitemno = value;
      }
    }

    public string ReportDesc
    {
      get
      {
        return this._reportdesc;
      }
      set
      {
        this._reportdesc = value;
      }
    }

    public int? isReceive
    {
      get
      {
        return this._isreceive;
      }
      set
      {
        this._isreceive = value;
      }
    }

    public string CountNodesItemSource
    {
      get
      {
        return this._countnodesitemsource;
      }
      set
      {
        this._countnodesitemsource = value;
      }
    }

    public string zdy1
    {
      get
      {
        return this._zdy1;
      }
      set
      {
        this._zdy1 = value;
      }
    }

    public string zdy2
    {
      get
      {
        return this._zdy2;
      }
      set
      {
        this._zdy2 = value;
      }
    }

    public string zdy3
    {
      get
      {
        return this._zdy3;
      }
      set
      {
        this._zdy3 = value;
      }
    }

    public string zdy4 { get; set; }

    public string zdy5 { get; set; }

    public string SerialNo { get; set; }

    public Decimal? ReportValue { get; set; }

    public string Unit { get; set; }

    public string RefRange { get; set; }

    public string ResultStatus { get; set; }

    public DateTime? ItemTime { get; set; }

    public DateTime? ItemDate { get; set; }
  }
}
