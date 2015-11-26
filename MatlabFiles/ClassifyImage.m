function [ catogaryLable ] = ClassifyImage ( inputImg )

%Loading Image Catogery Classifier
categoryClassifier = load('variable');

% classify the next loaded image
img = imread(inputImg);
[labelIdx, ~] = predict(categoryClassifier.categoryClassifier, img);
catogaryLable = categoryClassifier.categoryClassifier.Labels(labelIdx);
end

