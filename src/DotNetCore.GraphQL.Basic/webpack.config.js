var webpack = require('webpack');
var ExtractTextPlugin = require('extract-text-webpack-plugin');

var output = './wwwroot';

module.exports = {
    entry: {
        'bundle': './GraphiQL/app.js'
    },

    output: {
        path: output,
        filename: '[name].js'
    },

    resolve: {
        extensions: ['.js', '.json']
    },

    module: {
        loaders: [
            {
                test: /\.js/,
                loader: 'babel-loader',
                query: {
                    presets: ['es2015', 'react', 'stage-1']
                }
            },
            {
                test: /\.css$/,
                loader: ExtractTextPlugin.extract({
                    fallback: 'style-loader',
                    use: 'css-loader'
                })
            }
        ]
    },

    plugins: [
        new ExtractTextPlugin({ filename: 'style.css', allChunks: true })
    ]
};
