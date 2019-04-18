using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Editor
{

    [CreateAssetMenu(menuName = "Save Game Pro/Integration Info")]
    public class IntegrationInfo : ScriptableObject
    {

        [SerializeField]
        protected string identifier;
        [SerializeField]
        protected string title;
        [SerializeField]
        protected string version = "1.0.0";
        [SerializeField]
        protected string packageName = "Integration";
        [TextArea(5, 5)]
        [SerializeField]
        protected string description;
        [TextArea(5, 5)]
        [SerializeField]
        protected string changelog;
        [SerializeField]
        protected string[] contents;
        [SerializeField]
        protected string[] dependencies;
        [SerializeField]
        protected LinkInfo[] links;
        [HideInInspector]
        [SerializeField]
        protected List<string> dependents = new List<string>();
        [HideInInspector]
        [SerializeField]
        protected bool installed = false;

        public virtual string Identifier
        {
            get
            {
                return this.identifier;
            }
        }

        public virtual string Title
        {
            get
            {
                return this.title;
            }
        }

        public virtual string Version
        {
            get
            {
                return this.version;
            }
        }

        public virtual string PackageName
        {
            get
            {
                return this.packageName;
            }
        }

        public virtual string Description
        {
            get
            {
                return this.description;
            }
        }

        public virtual string Changelog
        {
            get
            {
                return this.changelog;
            }
        }

        public virtual string[] Contents
        {
            get
            {
                return this.contents;
            }
        }

        public virtual string[] Dependencies
        {
            get
            {
                return this.dependencies;
            }
        }

        public virtual LinkInfo[] Links
        {
            get
            {
                return this.links;
            }
        }

        public virtual List<string> Dependents
        {
            get
            {
                return this.dependents;
            }
            set
            {
                this.dependents = value;
            }
        }

        public virtual bool Installed
        {
            get
            {
                return this.installed;
            }
            set
            {
                this.installed = value;
            }
        }

    }

}