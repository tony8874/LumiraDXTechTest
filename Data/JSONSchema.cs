using System;
using System.Collections.Generic;
using System.Text;

namespace LumiraDXTech.Data
{
    public static class PayloadSchemas
    {
        public static string GETCategorySchema = @"{'type':'array','items':[{'type':'object','properties':{'id':{'type': 'integer'},'name': {'type': 'string'}},'required': ['id','name']}]}";
        public static string GETCategoryPostSchema = @"{
  'type': 'object',
  'properties': {
    'id': {
      'type': 'integer'
    },
    'name': {
      'type': 'string'
    },
    'posts': {
      'type': 'array',
      'items': [
        {
          'type': 'object',
          'properties': {
            'body': {
              'type': 'string'
            },
            'category': {
              'type': 'string'
            },
            'category_id': {
              'type': 'integer'
            },
            'id': {
              'type': 'integer'
            },
            'pub_date': {
              'type': 'string'
            },
            'title': {
              'type': 'string'
            }
          },
          'required': [
            'body',
            'category',
            'category_id',
            'id',
            'pub_date',
            'title'
          ]
        }
      ]
    }
  },
  'required': [
    'id',
    'name',
    'posts'
  ]
}";
    }
     
}
