﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace FrmDemoControl
{
    public partial class Common
    {

        #region 系统参数设置

        /// <summary>
        /// 公司编号
        /// </summary>
        public static String _companyno = "";

        /// <summary>
        /// 权限功能画面
        /// </summary>
        public static StringDictionary _dicRoleInfo;

        /// <summary>
        /// 权限Id
        /// </summary>
        public static string _authorid = "";

        /// <summary>
        /// 是否为历史数据
        /// </summary>
        public static bool _isHistory = false;

        /// <summary>
        /// 权限名称
        /// </summary>
        public static string _authornm = "";

        /// <summary>
        /// 系统配置文件名称
        /// </summary>
        public static String _settingfilename = "MachineSystem.dat";

        /// <summary>
        /// 登录用户信息
        /// </summary>
        public static string _userInfo = "users.ini";

        #endregion

        #region 共通参数设置

        /// <summary>
        /// 系统名称
        /// </summary>
        public static string _SysName = "";

        /// <summary>
        /// 系统默认超级管理员ID
        /// </summary>
        public static string _Administrator = "admin";

        /// <summary>
        /// 登录用户编号
        /// </summary>
        public static string _personid = "";

        /// <summary>
        /// 登录用户密码
        /// </summary>
        public static string _personpswd = "";
        /// <summary>
        /// 登录用户名称
        /// </summary>
        public static string _personname = "";
        /// <summary>
        /// 用户所在部门id
        /// </summary>
        public static string _PerSonDeptId = "";
        /// <summary>
        /// 用户所在部门名称
        /// </summary>
        public static string _PerSonDeptName = "";

        /// <summary>
        /// 向别id
        /// </summary>
        public static string _JobForId = "";

        /// <summary>
        /// 向别名称
        /// </summary>
        public static string _JobForName = "";

        /// <summary>
        /// 工程别id
        /// </summary>
        public static string _ProjectId = "";

        /// <summary>
        /// 工程别名称
        /// </summary>
        public static string _ProjectName = "";

        /// <summary>
        /// Line别id
        /// </summary>
        public static string _LineId = "";

        /// <summary>
        /// Line别名称
        /// </summary>
        public static string _LineName = "";

        /// <summary>
        /// 班别id
        /// </summary>
        public static string _TeamId = "";

        /// <summary>
        /// 班别名称
        /// </summary>
        public static string _TeamName = "";

        /// <summary>
        /// 向别-班别
        /// </summary>
        public static string _myTeamName = "";

        /// <summary>
        /// 工程别-班别
        /// </summary>
        public static string _orgTeamName = "";

        /// <summary>
        /// 关位id
        /// </summary>
        public static string _GuanweiId = "";

        /// <summary>
        /// 关位名称
        /// </summary>
        public static string _GuanweiName = "";

        /// <summary>
        /// 职等id
        /// </summary>
        public static string _DutyId = "";

        /// <summary>
        /// 职等名称
        /// </summary>
        public static string _DutyName = "";

        /// <summary>
        /// 当前用户状态id
        /// </summary>
        public static string _StatusId = "";

        /// <summary>
        /// 当前用户状态名称
        /// </summary>
        public static string _StatusName = "";


        //===========获取头像所用信息

        //人事系统头像共享文件夹
        public static string EmPathDir = "";

        //考勤系统头像目录
        public static string AtPathDir = "";


        //人事系统ip地址
        //考勤系统ip（车间）
        public static string EmHttpIpWork = "";

        //考勤系统ip（办公室）
        public static string EmHttpIpRoom = "";

        /// <summary>
        /// 网上图片IP address
        /// http://192.168.1.120/USER_PIC/
        /// </summary>
        public static string getImageHttpURL = @"http://192.168.1.120/USER_PIC/";

        #endregion

    }

  
}
