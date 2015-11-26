%%%% Work Code for inage classification %%%%

function[categoryClassifier] = ImageClassifierLearning(natural, manmade)

% load natrual and manmade training set
trainingSets = [imageSet(natural), imageSet(manmade)];

% extracts SURF features from all images in all image categories
% constructs the visual vocabulary by reducing the number of features through quantization of feature space using K-means clustering
bag = bagOfFeatures(trainingSets);

% Encoded training images from each category are fed into a classifier training process
categoryClassifier = trainImageCategoryClassifier(trainingSets, bag);
save('variable','categoryClassifier');
% Test of the classifier on training sets
%confMatrix = evaluate(categoryClassifier, trainingSets);

end
