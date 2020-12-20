﻿namespace DomainLayer.Engine
{
    public abstract class Connection
    {
        public abstract Database<T> Create<T>(Model<T> model);
    }
}